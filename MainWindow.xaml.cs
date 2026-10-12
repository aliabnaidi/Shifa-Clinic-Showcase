using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using MediFlow.Models;
using MediFlow.Services;
using MediFlow.Views;

namespace MediFlow;

public partial class MainWindow : Window
{
    private void Sidebar_Home_Click(object sender, RoutedEventArgs e)
    {
        if (_activeUsername == "manager") Show(ManagerContainer);
        else if (_activeUsername == "reception") Show(ReceptionContainer);
        else if (ClinicDirectory.Staff.Any(s => s.Username == _activeUsername)) Show(StaffPortalContainer);
        else if (ClinicDirectory.Nurses.Any(n => n.Username == _activeUsername)) Show(NursingContainer);
        else Show(ActiveContainer);
    }
    private void Sidebar_Patients_Click(object sender, RoutedEventArgs e) { Refresh(); Show(PatientsContainer); }
    private void Sidebar_Appointments_Click(object sender, RoutedEventArgs e) { Refresh(); Show(AppointmentsContainer); }
    private void Sidebar_Visits_Click(object sender, RoutedEventArgs e) { Refresh(); Show(VisitsContainer); }
    private void Sidebar_Medications_Click(object sender, RoutedEventArgs e) { Refresh(); MedicationsSection.OpenPrescriptions(); Show(MedicationsContainer); }
    private void Sidebar_Treatments_Click(object sender, RoutedEventArgs e) { Refresh(); Show(TreatmentsContainer); }
    private void Sidebar_Inventory_Click(object sender, RoutedEventArgs e) { Refresh(); InventorySection.OpenInventory(); Show(InventoryContainer); }
    private void Doctor_AudioHistory(object sender, RoutedEventArgs e) { if (sender is DoctorDashboardView d) _activeDoctor = d; Refresh(); Show(AudioHistoryContainer); }
    private void Sidebar_Lab_Click(object sender, RoutedEventArgs e) { Refresh(); Show(LabContainer); }
    private void Sidebar_Reports_Click(object sender, RoutedEventArgs e) { Refresh(); Show(ReportsContainer); }
    private void Sidebar_Settings_Click(object sender, RoutedEventArgs e) { Refresh(); Show(SettingsContainer); }
    private void Sidebar_Attachments_Click(object sender, RoutedEventArgs e) { Refresh(); Show(FilesContainer); }
    private void Sidebar_SickLeave_Click(object sender, RoutedEventArgs e) { Refresh(); Show(SickLeaveContainer); }
    private void Sidebar_Register_Click(object sender, RoutedEventArgs e) { Refresh(); Show(PatientsContainer); }
    private void Sidebar_StartVisit_Click(object sender, RoutedEventArgs e) { Refresh(); Show(AppointmentsContainer); }
    private void Sidebar_PrescriptionHistory_Click(object sender, RoutedEventArgs e) { Refresh(); Show(MedicationsContainer); }
    private void Sidebar_IssueSickLeave_Click(object sender, RoutedEventArgs e) { Refresh(); Show(SickLeaveContainer); }
    private void Sidebar_Logout_Click(object sender, RoutedEventArgs e) => ShowLogin();


    private readonly List<PatientRecord> _patients = AppData.Patients;
    private PatientRecord? _selectedPatient;
    private DoctorDashboardView? _activeDoctor;
    private string _activeUsername = "";
    private UIElement? _pendingLoginView;
    private bool _startupReady;
    private bool _startupStarted;
    private bool _staffPortalActive;
    private SoundPlayer? _loginSuccessSound;
    private Stream? _loginSuccessStream;
    private readonly DispatcherTimer _sharedDataRefreshTimer = new() { Interval = TimeSpan.FromSeconds(3) };

    public MainWindow()
    {
        InitializeComponent();
        _sharedDataRefreshTimer.Tick += SharedDataRefreshTimer_Tick;
        _sharedDataRefreshTimer.Start();
        LoginView.SetReady(false);
        ContentRendered += MainWindow_ContentRendered;
        VisitEditor.PatientHistoryRequested += VisitEditor_PatientHistoryRequested;
    }

    private async void MainWindow_ContentRendered(object? sender, EventArgs e)
    {
        if (_startupStarted) return;
        _startupStarted = true;

        // Let WPF paint the login screen first. Loading the JSON snapshot and
        // configuring every dashboard in the constructor made startup feel heavy.
        await Task.Yield();
        await Task.Run(() => AppDataStore.Load());

        if (!string.IsNullOrWhiteSpace(AppDataStore.LastStorageError))
        {
            MessageBox.Show("تعذر الاتصال ببيانات العيادة المشتركة. لن يتم فتح النظام حتى لا تُحفظ بيانات على جهاز منفصل.\n\n" + AppDataStore.LastStorageError,
                "شفاء — التخزين المشترك", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        // Public demo uses separate storage; never delete existing patient records.
        Configure();
        Seed();
        Refresh();
        _startupReady = true;
        LoginView.SetReady(true);
        await Dispatcher.InvokeAsync(() => LoginView.Focus(), DispatcherPriority.ApplicationIdle);
    }

    private void Configure()
    {
        GeneralDoctor.ConfigureSpecialty("الطب البشري والعام", "طبيب تجريبي عام");
        DentalDoctor.ConfigureSpecialty("طب الأسنان", "طبيب تجريبي أسنان");
        GyneDoctor.ConfigureSpecialty("النسائية", "طبيبة تجريبية نسائية");
        PatientsSection.Configure("المرضى", "ملفات المرضى والبحث والمتابعة", "#55A9BA", "🩺", "المرضى");
        VisitsSection.Configure("الزيارات والسجل الطبي", "التشخيصات والملاحظات والحسابات", "#55A9BA", "📝", "الزيارات");
        AppointmentsSection.Configure("المواعيد", "حجز وتنظيم ومتابعة الحضور", "#55A9BA", "📅", "المواعيد");
        MedicationsSection.Configure("قسم الأدوية", "وصفات خارجية يشتريها المريض من الصيدلية", "#55A9BA", "💊", "الأدوية والوصفات");
        InventorySection.Configure("مخزون العيادة", "علاجات العيادة والمحاليل والإبر والمستلزمات", "#55A9BA", "▦", "الأدوية والوصفات");
        InventorySection.OpenInventory();
        AudioHistorySection.Configure("أرشيف التسجيلات الصوتية", "التسجيلات المحفوظة في ملفات المرضى مع الوقت والمدة والنص", "#55A9BA", "🎙", "التسجيلات الصوتية");
        LabSection.Configure("الفحوصات والمختبر", "طلبات الفحص والنتائج", "#55A9BA", "🧪", "المختبر");
        ReportsSection.Configure("التقارير والإحصائيات", "مؤشرات تشغيلية ومالية وطبية", "#55A9BA", "📊", "التقارير");
        SettingsSection.Configure("الإعدادات", "إعدادات العيادة والبيانات الأساسية", "#55A9BA", "⚙", "الإعدادات");
        SickLeaveSection.Configure("الإجازات المرضية", "إصدار ومتابعة الإجازات المرضية", "#55A9BA", "🩹", "الإجازات المرضية");
        FilesSection.Configure("الملفات والمرفقات", "ملفات العيادة وملفات المرضى", "#55A9BA", "📎", "الملفات والمرفقات");
    }

    private void Seed()
    {
        bool changed = false;
        // Nursing, reception, and accounting share one staff sign-in and the same
        // role-controlled portal. Preserve the first existing nurse credential as
        // the initial shared account when migrating older local data.
        if (ClinicDirectory.Staff.Count == 0 && ClinicDirectory.Nurses.FirstOrDefault(n => n.Active) is { } firstNurse)
        {
            ClinicDirectory.Staff.Add(new ClinicStaffAccount
            {
                Name = firstNurse.Name, Username = firstNurse.Username, Password = firstNurse.Password,
                CanNursing = true, CanReception = true, CanAccounting = true, Active = true
            });
            changed = true;
        }
        if (!ClinicDirectory.Staff.Any(s => s.Username.Equals("clinic", StringComparison.OrdinalIgnoreCase)))
        {
            ClinicDirectory.Staff.Add(new ClinicStaffAccount
            {
                Name = "موظف العيادة", Username = "clinic", Password = "1234",
                CanNursing = true, CanReception = true, CanAccounting = true, Active = true
            });
            changed = true;
        }
        if (ClinicDirectory.Nurses.Count > 0)
        {
            ClinicDirectory.Nurses.Clear();
            changed = true;
        }
        var demoStockNames = new HashSet<string>(new[] { "Normal Saline 500 ml", "Ringer Lactate 500 ml", "Dextrose 5% 500 ml", "IV Cannula", "Syringe 5 ml" }, StringComparer.OrdinalIgnoreCase);
        var demoStockIds = AppData.Inventory.Where(i => demoStockNames.Contains(i.Name)).Select(i => i.Id).ToHashSet(StringComparer.OrdinalIgnoreCase);
        if (demoStockIds.Count > 0)
        {
            AppData.Inventory.RemoveAll(i => demoStockIds.Contains(i.Id));
            AppData.InventoryMovements.RemoveAll(m => demoStockNames.Contains(m.ItemName));
            changed = true;
        }
        // Move legacy pharmacy medicines out of the clinic supply stock and into
        // the prescribing catalog. Keep their dosage metadata for existing Rx workflows.
        foreach (var medicine in AppData.Inventory.Where(i => i.Category == "دواء" || i.InventoryGroup == "الأدوية" || string.Equals(i.DosageForm, "Injection", StringComparison.OrdinalIgnoreCase) || i.Name.Contains("Injection", StringComparison.OrdinalIgnoreCase)).ToList())
        {
            medicine.Category = "دواء";
            medicine.InventoryGroup = "الأدوية";
            if (!AppData.PrescriptionCatalog.Any(x => string.Equals(x.Name, medicine.Name, StringComparison.OrdinalIgnoreCase)))
                AppData.PrescriptionCatalog.Add(medicine);
            AppData.Inventory.Remove(medicine);
            changed = true;
        }
        var allSpecialties = "الطب البشري والعام, طب الأسنان, النسائية";
        foreach (var name in AppData.MedicineCatalog.Where(n => !AppData.PrescriptionCatalog.Any(m => string.Equals(m.Name, n, StringComparison.OrdinalIgnoreCase))))
        {
            var tokens = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var unitTokenIndex = Array.FindLastIndex(tokens, t => t.Equals("mg", StringComparison.OrdinalIgnoreCase) || t.Equals("g", StringComparison.OrdinalIgnoreCase) || t.Equals("ml", StringComparison.OrdinalIgnoreCase));
            var strength = unitTokenIndex > 0 ? $"{tokens[unitTokenIndex - 1]} {tokens[unitTokenIndex]}" : "";
            var isInjection = name.Contains("Injection", StringComparison.OrdinalIgnoreCase);
            var isSyrup = name.Contains("Syrup", StringComparison.OrdinalIgnoreCase);
            AppData.PrescriptionCatalog.Add(new InventoryItem
            {
                Id = "RXMED-" + Guid.NewGuid().ToString("N")[..8].ToUpperInvariant(), Name = name,
                Category = "دواء", InventoryGroup = "الأدوية", InventorySubcategory = "أدوية عامة",
                Unit = isSyrup ? "مل" : isInjection ? "أمبولة" : "حبة",
                DosageForm = isSyrup ? "Syrup" : isInjection ? "Injection" : "Tablet",
                Strength = strength, Quantity = 0, ReorderLevel = 0, AllowedSpecialtiesText = allSpecialties
            });
            changed = true;
        }
        if (changed) AppDataStore.Save();
    }

    private void Refresh()
    {
        if (AppDataStore.IsSharedStorage)
        {
            AppDataStore.Load();
            if (!string.IsNullOrWhiteSpace(AppDataStore.LastStorageError))
            {
                MessageBox.Show("تعذر تحديث بيانات العيادة المشتركة. افحص اتصال الشبكة قبل المتابعة.\n\n" + AppDataStore.LastStorageError,
                    "شفاء — التخزين المشترك", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        GeneralDoctor.LoadPatients(_patients); DentalDoctor.LoadPatients(_patients); GyneDoctor.LoadPatients(_patients);
        Reception.LoadPatients(_patients);
        ManagerDashboard.RefreshData(); NursingDashboard.RefreshData();
        var specialty = _activeDoctor?.Specialty ?? "الطب البشري والعام";
        PatientsSection.SetData(_patients, AppData.Visits, specialty); VisitsSection.SetData(_patients, AppData.Visits, specialty);
        AppointmentsSection.SetData(_patients, AppData.Visits, specialty); MedicationsSection.SetData(_patients, AppData.Visits, specialty); InventorySection.SetData(_patients, AppData.Visits, specialty); AudioHistorySection.SetData(_patients, AppData.Visits, specialty);
        LabSection.SetData(_patients, AppData.Visits, specialty); ReportsSection.SetData(_patients, AppData.Visits, specialty); SettingsSection.SetData(_patients, AppData.Visits, specialty); SickLeaveSection.SetData(_patients, AppData.Visits, specialty);
        FilesSection.SetData(_patients, AppData.Visits, specialty);
    }

    private void SharedDataRefreshTimer_Tick(object? sender, EventArgs e)
    {
        if (!_startupReady || !AppDataStore.HasExternalChanges) return;

        // Do not replace live records while a user is editing a field or a clinical form.
        if (Keyboard.FocusedElement is TextBoxBase or PasswordBox or ComboBox or DatePicker) return;

        // Keep shared data synchronized on dashboards. A clinical form/profile holds
        // object references that must not be replaced mid-edit.
        bool onDashboard = StaffPortalContainer.Visibility == Visibility.Visible ||
                           ManagerContainer.Visibility == Visibility.Visible ||
                           GeneralContainer.Visibility == Visibility.Visible ||
                           DentalContainer.Visibility == Visibility.Visible ||
                           GyneContainer.Visibility == Visibility.Visible;
        if (onDashboard) Refresh();
    }

    private void Login_LoginRequested(object sender, RoutedEventArgs e)
    {
        if (!_startupReady) return;
        var l = LoginView;
        var u = (l.Username ?? string.Empty).Trim();
        var p = (l.Password ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(u) || string.IsNullOrWhiteSpace(p))
        {
            l.ShowError("يرجى إدخال اسم المستخدم وكلمة المرور.");
            return;
        }

        bool CredentialsMatch(string stored, string entered) => string.Equals(stored, entered, StringComparison.Ordinal);
        var staff = ClinicDirectory.Staff.FirstOrDefault(a => a.Active && CredentialsMatch(u, a.Username) && CredentialsMatch(p, a.Password));
        if (staff != null)
        {
            _activeUsername = staff.Username;
            _activeDoctor = null;
            ActivateStaffPortal(staff);
            ShowLoginSuccess("Staff", staff.Name, "التمريض • الاستقبال • المحاسبة", StaffPortalContainer);
            return;
        }

        // Manager
        if (u.Equals("manager", StringComparison.OrdinalIgnoreCase) || u.Equals("admin", StringComparison.OrdinalIgnoreCase))
        {
            if (p == "1234")
            {
                _activeUsername = "manager";
                _activeDoctor = null;
                l.SetLoginContext("Manager", "");
                ManagerDashboard.RefreshData();
                ShowLoginSuccess("Manager", "Manager", "Management");
                return;
            }
        }

        var doctor = ClinicDirectory.Doctors.FirstOrDefault(d =>
            d.Active && CredentialsMatch(u, d.Username) && CredentialsMatch(p, d.Password));

        if (doctor == null)
        {
            // Explicit legacy aliases.
            var alias = u.ToLowerInvariant();
            var mappedUsername = alias switch
            {
                "doctor" or "general" => "general1",
                "dentist" or "dental" => "dental1",
                "gyne" or "gynecology" => "gyne1",
                _ => string.Empty
            };

            if (!string.IsNullOrEmpty(mappedUsername) && ClinicDirectory.Doctors.Any(d => d.Active && d.Username == mappedUsername && d.Password == p))
                doctor = ClinicDirectory.Doctors.FirstOrDefault(d => d.Username == mappedUsername);
        }

        if (doctor != null)
        {
            _activeUsername = doctor.Username;
            l.SetLoginContext("Doctor", doctor.Specialty);
            _activeDoctor = doctor.Specialty == "طب الأسنان" ? DentalDoctor :
                            doctor.Specialty == "النسائية" ? GyneDoctor : GeneralDoctor;
            _activeDoctor.ConfigureSpecialty(doctor.Specialty, doctor.Name);
            Refresh();
            var doctorContainer = _activeDoctor == DentalDoctor ? DentalContainer :
                                  _activeDoctor == GyneDoctor ? GyneContainer : GeneralContainer;
            ShowLoginSuccess("Doctor", doctor.Name, doctor.Specialty, doctorContainer);
            return;
        }

        l.ShowError("بيانات الدخول غير صحيحة. راجع ملف معلومات الدخول المرفق بالمشروع.");
    }

    private void Manager_OpenPatient(object? sender, PatientRecord patient)
    {
        _selectedPatient = patient;
        PatientProfile.LoadPatient(patient);
        Show(ProfileContainer);
    }

    private void ShowLoginSuccess(string role, string displayName, string department, UIElement? destination = null)
    {
        _pendingLoginView = destination ?? (role == "Reception" ? ReceptionContainer :
            role == "Manager" ? ManagerContainer :
            role == "Nurse" ? NursingContainer : GeneralContainer);

        LoginView.Visibility = Visibility.Collapsed;
        HideAllExceptLoginSuccess();

        SuccessRoleText.Text = role switch
        {
            "Doctor" => "طبيب",
            "Nurse" => "تمريض",
            "Manager" => "مسؤول النظام",
            "Reception" => "الاستقبال والمحاسبة",
            "Staff" => "فريق العيادة",
            _ => role
        };
        SuccessNameText.Text = displayName;
        SuccessDepartmentText.Text = department;
        SuccessDateText.Text = DateTime.Now.ToString("dd/MM/yyyy");
        SuccessTimeText.Text = DateTime.Now.ToString("hh:mm", System.Globalization.CultureInfo.InvariantCulture) + (DateTime.Now.Hour < 12 ? " ص" : " م");

        LoginSuccessOverlay.Visibility = Visibility.Visible;
        PlayLoginSuccessSound();
        var show = (System.Windows.Media.Animation.Storyboard)FindResource("LoginSuccessEntrance");
        show.Begin(this, true);
    }

    private void PlayLoginSuccessSound()
    {
        try
        {
            if (_loginSuccessSound == null)
            {
                var resource = Application.GetResourceStream(new Uri("pack://application:,,,/Assets/LoginSuccess.wav"));
                if (resource != null)
                {
                    _loginSuccessStream = resource.Stream;
                    _loginSuccessSound = new SoundPlayer(_loginSuccessStream);
                }
            }
            _loginSuccessSound?.Play();
        }
        catch
        {
            // Audio is optional; a missing/unsupported sound must never affect login.
        }
    }

    private void HideAllExceptLoginSuccess()
    {
        GeneralContainer.Visibility = Visibility.Collapsed;
        DentalContainer.Visibility = Visibility.Collapsed;
        GyneContainer.Visibility = Visibility.Collapsed;
        PatientsContainer.Visibility = Visibility.Collapsed;
        VisitsContainer.Visibility = Visibility.Collapsed;
        AppointmentsContainer.Visibility = Visibility.Collapsed;
        MedicationsContainer.Visibility = Visibility.Collapsed;
        InventoryContainer.Visibility = Visibility.Collapsed;
        TreatmentsContainer.Visibility = Visibility.Collapsed;
        AudioHistoryContainer.Visibility = Visibility.Collapsed;
        LabContainer.Visibility = Visibility.Collapsed;
        ReportsContainer.Visibility = Visibility.Collapsed;
        SettingsContainer.Visibility = Visibility.Collapsed;
        SickLeaveContainer.Visibility = Visibility.Collapsed;
        FilesContainer.Visibility = Visibility.Collapsed;
        ManagerContainer.Visibility = Visibility.Collapsed;
        NursingContainer.Visibility = Visibility.Collapsed;
        ProfileContainer.Visibility = Visibility.Collapsed;
        VisitEditorContainer.Visibility = Visibility.Collapsed;
        MedicalFormContainer.Visibility = Visibility.Collapsed;
        ReceptionContainer.Visibility = Visibility.Collapsed;
        StaffPortalContainer.Visibility = Visibility.Collapsed;
    }

    private void LoginSuccessDone_Click(object sender, RoutedEventArgs e)
    {
        var destination = _pendingLoginView;
        _pendingLoginView = null;
        LoginSuccessOverlay.Visibility = Visibility.Collapsed;
        if (destination != null)
            Show(destination);
        AppSidebar.Visibility = Visibility.Collapsed;
    }

    private void Show(UIElement e)
    {
        if (!CanOpenPage(e)) return;
        HideAll(); e.Visibility = Visibility.Visible;
    }

    private bool CanOpenPage(UIElement target)
    {
        bool isStaffSession = ClinicDirectory.Staff.Any(s => s.Active &&
            string.Equals(s.Username, _activeUsername, StringComparison.OrdinalIgnoreCase)) ||
            string.Equals(_activeUsername, "reception", StringComparison.OrdinalIgnoreCase) ||
            ClinicDirectory.Nurses.Any(n => string.Equals(n.Username, _activeUsername, StringComparison.OrdinalIgnoreCase));
        if (isStaffSession && !ReferenceEquals(target, StaffPortalContainer) && !ReferenceEquals(target, LoginView))
        {
            MessageBox.Show("هذه الصفحة مخصصة للطبيب. بوابة فريق العيادة لا تتيح فتح ملفات المرضى أو صفحات الطبيب.",
                "صلاحيات الوصول", MessageBoxButton.OK, MessageBoxImage.Information);
            return false;
        }

        return true;
    }

    private void HideAll()
    {
        LoginView.Visibility=Visibility.Collapsed; GeneralContainer.Visibility=Visibility.Collapsed; DentalContainer.Visibility=Visibility.Collapsed; GyneContainer.Visibility=Visibility.Collapsed;
        PatientsContainer.Visibility=Visibility.Collapsed; VisitsContainer.Visibility=Visibility.Collapsed; AppointmentsContainer.Visibility=Visibility.Collapsed; MedicationsContainer.Visibility=Visibility.Collapsed; InventoryContainer.Visibility=Visibility.Collapsed; TreatmentsContainer.Visibility=Visibility.Collapsed; AudioHistoryContainer.Visibility=Visibility.Collapsed;
        LabContainer.Visibility=Visibility.Collapsed; ReportsContainer.Visibility=Visibility.Collapsed; SettingsContainer.Visibility=Visibility.Collapsed; SickLeaveContainer.Visibility=Visibility.Collapsed; FilesContainer.Visibility=Visibility.Collapsed; ProfileContainer.Visibility=Visibility.Collapsed;
        VisitEditorContainer.Visibility=Visibility.Collapsed; MedicalFormContainer.Visibility=Visibility.Collapsed; ReceptionContainer.Visibility=Visibility.Collapsed; ManagerContainer.Visibility=Visibility.Collapsed; NursingContainer.Visibility=Visibility.Collapsed; StaffPortalContainer.Visibility=Visibility.Collapsed;
    }
    private UIElement ActiveContainer => _activeDoctor == DentalDoctor ? DentalContainer : _activeDoctor == GyneDoctor ? GyneContainer : GeneralContainer;
    private void ShowLogin() { RestoreStaffPortal(); AppDataStore.Save(); AppSidebar.Visibility = Visibility.Collapsed; Show(LoginView); LoginView.ClearFields(); _activeDoctor=null; _selectedPatient=null; _activeUsername=""; }

    private void ActivateStaffPortal(ClinicStaffAccount staff)
    {
        if (!_staffPortalActive)
        {
            ReceptionContainer.Children.Remove(Reception);
            NursingContainer.Children.Remove(NursingDashboard);
            StaffReceptionTab.Content = Reception;
            StaffNursingTab.Content = NursingDashboard;
            _staffPortalActive = true;
        }
        StaffReceptionTab.Visibility = staff.CanReception || staff.CanAccounting ? Visibility.Visible : Visibility.Collapsed;
        StaffNursingTab.Visibility = staff.CanNursing ? Visibility.Visible : Visibility.Collapsed;
        StaffPortalTabs.SelectedItem = staff.CanReception || staff.CanAccounting ? StaffReceptionTab : StaffNursingTab;
        Reception.LoadPatients(_patients);
        NursingDashboard.ConfigureNurse(staff.Name);
        NursingDashboard.RefreshData();
    }

    private void RestoreStaffPortal()
    {
        if (!_staffPortalActive) return;
        StaffReceptionTab.Content = null;
        StaffNursingTab.Content = null;
        ReceptionContainer.Children.Add(Reception);
        NursingContainer.Children.Add(NursingDashboard);
        StaffReceptionTab.Visibility = Visibility.Visible;
        StaffNursingTab.Visibility = Visibility.Visible;
        _staffPortalActive = false;
    }
    private void Doctor_Logout(object s,RoutedEventArgs e)=>ShowLogin(); private void Reception_Logout(object s,RoutedEventArgs e)=>ShowLogin(); private void Manager_Logout(object s,RoutedEventArgs e)=>ShowLogin(); private void Nursing_Logout(object s,RoutedEventArgs e)=>ShowLogin();

    private void Doctor_OpenPatient(object s,RoutedEventArgs e){ if(s is DoctorDashboardView d)_activeDoctor=d; _selectedPatient=_activeDoctor?.SelectedPatient; if(_selectedPatient==null)return; PatientProfile.LoadPatient(_selectedPatient); Show(ProfileContainer); }
    private void Doctor_StartVisit(object s,RoutedEventArgs e){ if(s is DoctorDashboardView d)_activeDoctor=d; _selectedPatient=_activeDoctor?.SelectedPatient; if(_selectedPatient==null)return; if(_selectedPatient.Status!="بانتظار الطبيب" && _selectedPatient.Status!="قيد الفحص"){ MessageBox.Show("لا يمكن بدء الكشف قبل إنهاء الفحوصات الأولية في التمريض."); return; } VisitEditor.SetDoctor(_activeDoctor?.DoctorDisplayName??""); VisitEditor.LoadPatient(_selectedPatient); Show(VisitEditorContainer); }
    private void Doctor_Patients(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(PatientsContainer);} private void Doctor_Visits(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(VisitsContainer);} private void Doctor_Appointments(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(AppointmentsContainer);} private void Doctor_Medications(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();MedicationsSection.OpenPrescriptions();Show(MedicationsContainer);} private void Doctor_Lab(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(LabContainer);} private void Doctor_Reports(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(ReportsContainer);} private void Doctor_Settings(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(SettingsContainer);}
    private void Doctor_Inventory(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();InventorySection.OpenInventory();Show(InventoryContainer);}
    private void Doctor_Treatments(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(TreatmentsContainer);}
    private void Doctor_Attachments(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(FilesContainer);}
    private void Doctor_SickLeave(object s,RoutedEventArgs e){if(s is DoctorDashboardView d)_activeDoctor=d;Refresh();Show(SickLeaveContainer);}
    private void Section_Action(object? sender,SectionActionEventArgs e)
    {
        if (e.Action == "OpenReceptionAppointment")
        {
            Reception.OpenAppointmentBooking();
            Show(ReceptionContainer);
            return;
        }
        try
        {
            if (e.Item is PatientRecord p)
            {
                _selectedPatient = p;
            if (e.Action == "StartVisit")
            {
                // من قائمة ملفات المرضى يمكن بدء زيارة متابعة لمريض مكتمل أيضًا.
                // أما المرضى الذين ما زالوا في مراحل التمريض/الدفع فلا يُسمح بتجاوز مسارهم.
                if (p.Status != "بانتظار الطبيب" && p.Status != "قيد الفحص" && p.Status != "مكتمل")
                {
                    MessageBox.Show("المريض لا يزال في مرحلة التمريض أو الدفع.");
                    return;
                }
                VisitEditor.SetDoctor(_activeDoctor?.DoctorDisplayName ?? "");
                VisitEditor.LoadPatient(p);
                Show(VisitEditorContainer);
            }
            else
            {
                PatientProfile.LoadPatient(p);
                Show(ProfileContainer);
            }
            return;
        }

        if (e.Action == "OpenLab" && e.Item is LabRecord lab)
        {
            LabSection.OpenLabRequest(lab);
            return;
        }

        var id = e.Item switch
        {
            AppointmentRecord a => a.PatientId,
            VisitRecord v => v.PatientId,
            MedicationRecord m => m.PatientId,
            LabRecord l => l.PatientId,
            SickLeaveRecord sl => sl.PatientId,
            _ => null
        };

        if (id != null)
        {
            _selectedPatient = _patients.FirstOrDefault(p => p.Id == id);
            if (_selectedPatient != null && e.Action == "OpenPatient")
            {
                PatientProfile.LoadPatient(_selectedPatient);
                Show(ProfileContainer);
            }
        }

            if (e.Action == "DataChanged" || e.Action == "Refresh" || e.Action == "SaveSettings")
            {
                AppDataStore.Save();
                Refresh();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء فتح أو تعديل ملف المريض، لكن البرنامج سيبقى مفتوحًا.\n\nالتفاصيل: {ex.Message}", "MediFlow", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    private void Section_Back(object s,RoutedEventArgs e)=>Show(ActiveContainer);
    private void Profile_Back(object s,RoutedEventArgs e)=>Show(ActiveContainer);
    private void Visit_Updated(object s,RoutedEventArgs e)
    {
        try
        {
            AppDataStore.Save();
            Refresh();
            if (_selectedPatient != null)
                PatientProfile.LoadPatient(_selectedPatient);
            Show(ProfileContainer);
            MessageBox.Show("تم حفظ تعديل الزيارة الأخيرة داخل ملف المريض بنجاح.", "MediFlow", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"تم حفظ التعديل، لكن تعذر تحديث شاشة ملف المريض دون إغلاق البرنامج.\n\nالتفاصيل: {ex.Message}", "MediFlow", MessageBoxButton.OK, MessageBoxImage.Warning);
            Show(ProfileContainer);
        }
    }
    private void Profile_StartVisit(object s,RoutedEventArgs e){if(_selectedPatient==null)return;if(_selectedPatient.Status!="بانتظار الطبيب" && _selectedPatient.Status!="قيد الفحص"){MessageBox.Show("المريض لا يمكن إدخاله للكشف قبل إنهاء مرحلة التمريض.");return;}VisitEditor.SetDoctor(_activeDoctor?.DoctorDisplayName??"");VisitEditor.LoadPatient(_selectedPatient);Show(VisitEditorContainer);}
    private void Visit_Back(object s,RoutedEventArgs e)=>Show(ProfileContainer);
    private void VisitEditor_PatientHistoryRequested(object? sender, RoutedEventArgs e)
    {
        if (_selectedPatient == null && sender is CurrentVisitView v) _selectedPatient = v.Patient;
        if (_selectedPatient == null) return;
        PatientProfile.LoadPatient(_selectedPatient);
        Show(ProfileContainer);
    }



    private void Visit_SendToReception(object s,RoutedEventArgs e)
    {
        if(_selectedPatient==null) return; var bill=VisitEditor.LastBill; if(bill==null)return;
        var now=DateTime.Now; var clinicSheet=_activeDoctor?.Specialty=="الطب البشري والعام"?VisitEditor.GetMedicalSheet():null; _selectedPatient.Bill=bill; _selectedPatient.Status="بانتظار التمريض للعلاج"; _selectedPatient.DoctorToReceptionAt=now;
        _selectedPatient.TreatmentHandoffAt=now; _selectedPatient.ClinicTreatmentStatus="بانتظار التنفيذ"; _selectedPatient.ClinicTreatmentReason=""; _selectedPatient.ClinicTreatmentUpdatedAt=now;
        _selectedPatient.ClinicTreatmentRequests=clinicSheet==null?"":string.Join(" • ",new[]{clinicSheet.Injection,clinicSheet.IVFluid,clinicSheet.LabProcedure,clinicSheet.Suture,clinicSheet.Dressing}.Where(x=>!string.IsNullOrWhiteSpace(x)).Distinct());
        var visit=new VisitRecord { Id="VIS-"+Guid.NewGuid().ToString("N")[..8].ToUpperInvariant(), PatientId=_selectedPatient.Id, PatientName=_selectedPatient.Name, Specialty=_selectedPatient.Specialty, Diagnosis=bill.Diagnosis, Notes=VisitEditor.NotesForTransfer, Doctor=_activeDoctor?.DoctorDisplayName??"", Total=bill.Total, AudioPath=VisitEditor.LastAudioPath??"", AudioDurationSeconds=VisitEditor.LastAudioDurationSeconds, SentToReception=true, SentToReceptionAt=now, PatientEntryAt=_selectedPatient.PatientEntryAt, NurseName=_selectedPatient.NurseName, NursingAssessmentCompletedAt=_selectedPatient.NursingAssessmentCompletedAt, TreatmentHandoffAt=now, ClinicTreatmentStatus="بانتظار التنفيذ", ClinicTreatmentUpdatedAt=now, MedicalSheet=clinicSheet };
        AppData.Visits.Insert(0,visit);
        AppData.Accounts.Add(new AccountEntry{Id="ACC-"+Guid.NewGuid().ToString("N")[..8].ToUpperInvariant(),VisitId=visit.Id,PatientId=_selectedPatient.Id,PatientName=_selectedPatient.Name,Specialty=_selectedPatient.Specialty,Doctor=_activeDoctor?.DoctorDisplayName??"",Description=$"زيارة — {bill.Diagnosis}",Amount=bill.Total,Paid=0,PaymentMethod=bill.PaymentMethod});
        AppData.Notifications.Insert(0,new NotificationRecord{Id="NT-"+Guid.NewGuid().ToString("N")[..8],Title="تحويل المريض إلى التمريض",Message=$"أنهى {visit.Doctor} كشف {_selectedPatient.Name}، وأرسل تعليمات علاج العيادة إلى التمريض. الحساب متاح للاستقبال بصورة مستقلة.",Specialty=_selectedPatient.Specialty,Type="تمريض",Date=now});
        if (!AppDataStore.Save())
        {
            MessageBox.Show("تعذر حفظ التحويل في قاعدة البيانات المشتركة؛ لم يتم تأكيد إرسال المريض. افحص اتصال الشبكة ثم أعد المحاولة.\n\n" + AppDataStore.LastStorageError,
                "تعذر حفظ التحويل", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        Refresh();
        if (!string.IsNullOrWhiteSpace(AppDataStore.LastStorageError))
        {
            MessageBox.Show("تم حفظ التحويل، لكن تعذر تحديث البيانات بعد الحفظ. افحص اتصال الشبكة.\n\n" + AppDataStore.LastStorageError,
                "تعذر تحديث البيانات", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }
        MessageBox.Show("تم تحويل المريض وتعليمات علاج العيادة إلى بوابة التمريض. الحساب والدفع لدى الاستقبال بصورة مستقلة.","شفاء",MessageBoxButton.OK,MessageBoxImage.Information); Show(ActiveContainer);
    }

    private void Reception_OpenVisitForm(object? s,VisitEventArgs e){var p=_patients.FirstOrDefault(x=>x.Id==e.Visit.PatientId);if(p==null)return;_selectedPatient=p;MedicalForm.LoadForm(e.Visit,p);Show(MedicalFormContainer);}
    private void Reception_PrintVisitForm(object? s,VisitEventArgs e){var p=_patients.FirstOrDefault(x=>x.Id==e.Visit.PatientId);if(p!=null)Services.MedicalFormPrinter.Print(e.Visit,p);}
    private void MedicalForm_Back(object s,RoutedEventArgs e)=>Show(ReceptionContainer);
    private void Reception_PatientCreated(object? s,PatientCreatedEventArgs e){if(!_patients.Any(p=>p.Id==e.Patient.Id))_patients.Add(e.Patient);AppDataStore.Save();Refresh();}
    private void Reception_PaymentRequested(object? s,PaymentRequestedEventArgs e)
    {
        var p=e.Patient;
        if(p.Bill==null) return;
        if(p.Status!="بانتظار الدفع" && p.Status!="محول للاستقبال" && p.Status!="بانتظار التمريض للعلاج" && p.Status!="قيد العلاج" && p.Status!="علاج متوقف مؤقتًا" && p.Status!="مكتمل") { MessageBox.Show("هذا المريض ليس لديه حساب مستحق للاستقبال."); return; }
        if(p.Bill.Total<=0) { MessageBox.Show("يجب أن يكون مبلغ الحساب أكبر من صفر."); return; }
        if (e.PaymentType == "تسجيل على الحساب (دين)")
        {
            var debtVisit = AppData.Visits.Where(v => v.PatientId == p.Id && v.SentToReception).OrderByDescending(v => v.SentToReceptionAt).FirstOrDefault();
            var debtAccount = (debtVisit == null ? null : AppData.Accounts.FirstOrDefault(a => a.VisitId == debtVisit.Id && a.Amount > 0))
                ?? AppData.Accounts.Where(a => a.PatientId == p.Id && a.Amount > 0 && a.Paid < a.Amount).OrderByDescending(a => a.Date).FirstOrDefault();
            if (debtAccount == null)
            {
                debtAccount = new AccountEntry { Id="ACC-"+Guid.NewGuid().ToString("N")[..8].ToUpperInvariant(), VisitId=debtVisit?.Id ?? "", PatientId=p.Id, PatientName=p.Name, Specialty=p.Specialty, Doctor=p.Doctor, Description=$"زيارة على الحساب — {p.Bill.Diagnosis}", Amount=p.Bill.Total, Paid=0, Date=DateTime.Now, PaymentMethod="على الحساب", CreatedBy=_activeUsername };
                AppData.Accounts.Add(debtAccount);
            }
            p.Bill.Paid = false;
            p.Bill.PaymentMethod = "على الحساب";
            AppData.Notifications.Insert(0, new NotificationRecord { Id="NT-"+Guid.NewGuid().ToString("N")[..8], Title="تسجيل الزيارة على الحساب", Message=$"سجّل الاستقبال حساب المريض {p.Name} كدين مستحق بقيمة {Math.Max(0m, debtAccount.Amount - debtAccount.Paid):0.00} د.أ.", Specialty=p.Specialty, Type="مالية", Date=DateTime.Now });
            AppDataStore.Save(); Refresh();
            MessageBox.Show($"تم تسجيل حساب {p.Name} على الحساب. الرصيد المستحق: {Math.Max(0m, debtAccount.Amount - debtAccount.Paid):0.00} د.أ.", "MediFlow", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }
        if (e.Amount <= 0)
        {
            MessageBox.Show("أدخل مبلغًا أكبر من صفر.");
            return;
        }
        var visit=AppData.Visits.Where(v=>v.PatientId==p.Id && v.SentToReception).OrderByDescending(v => v.SentToReceptionAt).FirstOrDefault();
        var acc = (visit == null ? null : AppData.Accounts.FirstOrDefault(a => a.VisitId == visit.Id && a.Amount > 0))
            ?? AppData.Accounts.Where(a => a.PatientId==p.Id && a.Amount > 0 && a.Paid < a.Amount).OrderByDescending(a => a.Date).FirstOrDefault();
        var alreadyPaid = acc?.Paid ?? 0m;
        var balance = Math.Max(0m, p.Bill.Total - alreadyPaid);
        bool extra = e.PaymentType == "مبلغ زائد / رصيد";
        if (extra && e.Amount < balance)
        {
            MessageBox.Show($"المبلغ لا يغطي الرصيد الحالي ({balance:0.00} د.أ). سجله كدفعة جزئية أو أدخل المبلغ الكامل مع الزيادة.");
            return;
        }
        if (!extra && e.Amount > balance)
        {
            MessageBox.Show($"المبلغ يتجاوز الرصيد المتبقي ({balance:0.00} د.أ). اختر (مبلغ زائد / رصيد) لتسجيله كرصيد للمريض.");
            return;
        }
        if (e.PaymentType == "سداد كامل" && !extra && e.Amount < balance)
        {
            MessageBox.Show($"السداد الكامل يتطلب دفع الرصيد كاملًا: {balance:0.00} د.أ.");
            return;
        }
        var now = DateTime.Now;
        var transactionVisitId = visit?.Id ?? "";
        if (acc == null && balance > 0)
        {
            acc = new AccountEntry { Id="ACC-"+Guid.NewGuid().ToString("N")[..8].ToUpperInvariant(), VisitId=transactionVisitId, PatientId=p.Id, PatientName=p.Name, Specialty=p.Specialty, Doctor=p.Doctor, Description=$"زيارة — {p.Bill.Diagnosis}", Amount=p.Bill.Total, Paid=0, Date=now, PaymentMethod=e.PaymentMethod, CreatedBy=_activeUsername };
            AppData.Accounts.Add(acc);
        }
        if (acc != null)
        {
            var applied = extra ? balance : e.Amount;
            acc.Paid += applied; acc.PaidAt = now; acc.PaymentMethod = e.PaymentMethod;
        }
        var extraAmount = extra ? e.Amount - balance : 0m;
        if (extraAmount > 0)
            AppData.Accounts.Add(new AccountEntry { Id="ACC-"+Guid.NewGuid().ToString("N")[..8].ToUpperInvariant(), VisitId=transactionVisitId, PatientId=p.Id, PatientName=p.Name, Specialty=p.Specialty, Doctor=p.Doctor, Description="رصيد مقدم للمريض", Amount=0, Paid=extraAmount, PaidAt=now, Date=now, PaymentMethod=e.PaymentMethod, CreatedBy=_activeUsername });
        AppData.PaymentTransactions.Insert(0, new PaymentTransaction { Id="PAY-"+Guid.NewGuid().ToString("N")[..8].ToUpperInvariant(), PatientId=p.Id, PatientName=p.Name, Specialty=p.Specialty, VisitId=transactionVisitId, Amount=e.Amount, PaymentType=e.PaymentType, Method=e.PaymentMethod, ReceivedBy=ClinicDirectory.Staff.FirstOrDefault(x => x.Username == _activeUsername)?.Name ?? _activeUsername, PaidAt=now });
        p.Bill.Paid = (acc?.Paid ?? 0m) >= p.Bill.Total;
        p.Bill.PaymentMethod = e.PaymentMethod;
        p.PaymentAt ??= now;
        if (visit != null) visit.PaidAt = now;
        AppData.Notifications.Insert(0,new NotificationRecord{Id="NT-"+Guid.NewGuid().ToString("N")[..8],Title=extra?"تم تسجيل رصيد للمريض":"تم تسجيل دفعة",Message=$"تم تسجيل {e.PaymentType} للمريض {p.Name}: {e.Amount:0.00} د.أ • {e.PaymentMethod}. {(extra ? "حُفظت كرصيد مقدم." : $"المتبقي: {Math.Max(0m, p.Bill.Total - (acc?.Paid ?? 0m)):0.00} د.أ. حالة علاج العيادة: {p.ClinicTreatmentStatus}.")}",Specialty=p.Specialty,Type="مالية",Date=now});
        AppDataStore.Save(); Refresh();
        MessageBox.Show(extra ? $"تم تسجيل مبلغ {e.Amount:0.00} د.أ كرصيد للمريض {p.Name}." : $"تم تسجيل دفعة {e.Amount:0.00} د.أ للمريض {p.Name}.\nالمتبقي: {Math.Max(0m, p.Bill.Total - (acc?.Paid ?? 0m)):0.00} د.أ.","MediFlow",MessageBoxButton.OK,MessageBoxImage.Information);
    }
    private void Minimize_Click(object s,RoutedEventArgs e)=>WindowState=WindowState.Minimized; private void Close_Click(object s,RoutedEventArgs e){AppDataStore.Save();Close();}
}
