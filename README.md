<div dir="rtl" align="right">
# الوصف الوظيفي والتقني لمشروع شفاء — Shifa

**اسم المشروع:** شفاء — Shifa  
**الإصدار الموصوف:** 1.0.2  
**نوع النظام:** تطبيق مكتبي لإدارة العيادات وتنظيم الإجراءات الطبية والإدارية والمالية.  
**بيئة التشغيل المستهدفة:** Windows 10 وWindows 11، بمعمارية 64 بت.  
**المطوّر:** علي راغب العايدي  
**حساب المطوّر:** https://github.com/aliabnaidi

## 1. التعريف بالمشروع

شفاء هو نظام مكتبي يهدف إلى تنظيم العمل اليومي داخل العيادات، من خلال ربط تسجيل المراجعين والتقييم التمريضي والكشف الطبي والحسابات وتنفيذ العلاج ضمن مسار عمل واحد.

يوفّر النظام واجهات للأطباء وفريق العيادة والإدارة، ويجمع بيانات المراجع وزياراته ومواعيده ووصفاته وفحوصاته ومرفقاته وحركاته المالية في سجلات مترابطة. كما يتضمن إدارة مخزون العيادة، وإعداد قواعد حساب الجرعات، والتسجيل الصوتي، وتكاملًا اختياريًا مع خدمات الذكاء الاصطناعي.

تدعم النسخة الحالية ثلاثة تخصصات أساسية: الطب البشري والعام، وطب الأسنان، والنسائية. ويعتمد المشروع على تطبيق مكتبي يعمل محليًا، مع إمكانية إعداد مجلد مشترك لتبادل البيانات بين أجهزة العيادة.

## 2. أهداف المشروع والقيمة التشغيلية

يهدف المشروع إلى تحقيق مجموعة من الأهداف العملية:

- تنظيم انتقال المراجع بين الاستقبال والتمريض والطبيب والحسابات.
- تجميع المعلومات الطبية والإدارية المتعلقة بالمراجع في ملف قابل للبحث والمتابعة.
- تقليل تكرار إدخال البيانات بين الأقسام.
- توثيق الزيارات والإجراءات والوصفات وطلبات الفحوصات.
- متابعة المبالغ المستحقة والمدفوعة والأرصدة المالية.
- مراقبة مخزون العيادة وتسجيل حركات الإضافة والصرف.
- توفير مؤشرات وتقارير تساعد الإدارة على متابعة التشغيل.
- تسهيل إعداد النماذج الطبية وطباعتها.
- دعم التوثيق الصوتي والتحويل الاختياري من الصوت إلى نص.

تمثل هذه الوظائف أساسًا لتقييم النظام داخل بيئة عمل فعلية، وقياس أثره على سرعة الإجراءات ودقة التوثيق بعد إجراء الاختبارات التشغيلية المناسبة.

## 3. المستخدمون والأدوار

يحتوي النظام على حسابات للأطباء والإدارة وفريق العيادة، مع تخصيص تجربة الاستخدام بحسب الدور.

| الدور | نطاق الاستخدام |
|---|---|
| الطبيب | الكشف الطبي، متابعة ملفات المراجعين، توثيق الزيارات، الوصفات، الفحوصات والإجراءات |
| الإدارة | متابعة مؤشرات التشغيل، الأقسام، الخدمات، المخزون، الموردين، المشتريات والمصروفات |
| الاستقبال | تسجيل المراجعين، حجز المواعيد، متابعة الحضور والإحالات |
| التمريض | التقييم الأولي، تسجيل العلامات الحيوية، متابعة العلاج وتنفيذه |
| المحاسبة | تسجيل الدفعات ومتابعة الحسابات والأرصدة |
| فريق العيادة الموحد | الوصول إلى وظائف التمريض والاستقبال والمحاسبة بحسب الصلاحيات الممنوحة |

تتيح إعدادات حسابات الفريق تحديد إمكانية الوصول إلى التمريض والاستقبال والمحاسبة. وتعرض بوابة الفريق الوظائف المتاحة للحساب، بينما تفرض الواجهة قيودًا على انتقال حسابات الفريق إلى صفحات الطبيب.

في النسخة التجريبية الحالية، أُزيلت كلمات المرور الإضافية للأقسام والإعدادات، مع الإبقاء على تسجيل الدخول وصلاحيات الحسابات.

## 4. مسار العمل داخل العيادة

يعتمد النظام على مسار تشغيلي يبدأ بتسجيل المراجع وينتهي بإتمام الخدمات المرتبطة بزيارته:

1. **الاستقبال:** تسجيل مراجع جديد أو اختيار ملف موجود وتحديد التخصص والطبيب.
2. **التقييم التمريضي الأولي:** إدخال العلامات الحيوية والحالات المزمنة والملاحظات.
3. **الكشف الطبي:** توثيق الشكوى والفحص والتشخيص والخطة العلاجية.
4. **إعداد الخدمات:** إضافة الوصفات وطلبات المختبر والأشعة وعلاج العيادة وبنود الحساب.
5. **الإحالة:** تحويل المعلومات ذات الصلة إلى الاستقبال وفريق التمريض.
6. **المتابعة المالية:** تسجيل الدفعات والمبالغ المتبقية أو الأرصدة المقدمة.
7. **تنفيذ العلاج:** متابعة إجراءات العلاج وتوثيق المواد المصروفة من المخزون.
8. **الأرشفة:** حفظ المعلومات ضمن سجل المراجع والزيارة.

يتضمن نموذج البيانات أوقاتًا لمراحل مختلفة، مثل دخول المراجع وبدء التقييم التمريضي والتحويل والدفع وتسليم العلاج وإتمامه، بما يدعم متابعة تسلسل الإجراءات.

## 5. إدارة المراجعين والملفات الطبية

يوفّر النظام ملفًا للمراجع يجمع البيانات الأساسية والطبية والإدارية. تشمل الحقول المتاحة الاسم، ورقم الملف، والعمر، والجنس، وتاريخ الميلاد، وأرقام الاتصال، والبريد الإلكتروني، والرقم الوطني، والعنوان، والمهنة والحالة الاجتماعية.

كما يتضمن معلومات عن التخصص والطبيب، ونوع الزيارة، والحساسية، والأمراض المزمنة، وفصيلة الدم، والتأمين، وجهة اتصال الطوارئ والملاحظات.

تشمل وظائف الملف:

- تسجيل المراجعين وتحديث بياناتهم.
- البحث عن الملفات.
- عرض اقتراحات لملفات موجودة أثناء التسجيل.
- استعراض التاريخ المرتبط بالمراجع.
- البحث داخل عناصر السجل وتصفيتها بحسب الفئة.
- عرض تفاصيل الزيارات السابقة.
- إضافة الملاحظات السريرية.
- الوصول إلى التسجيلات الصوتية المرتبطة بالمراجع.
- بدء زيارة جديدة من الملف.

يعتمد ربط البيانات على معرّفات للمراجع والزيارة والسجلات المرتبطة، مثل طلبات الفحص والوصفات والدفعات.

## 6. المواعيد والاستقبال

تتيح وحدة الاستقبال تسجيل المراجعين وحجز المواعيد وربطها بالتخصص والطبيب. ويحتوي سجل الموعد على بيانات تشمل التاريخ والوقت ونوع الموعد والحالة والمدة والملاحظات.

تشمل الوظائف:

- حجز موعد لمراجع موجود أو تسجيل بيانات الموعد.
- اختيار التخصص والطبيب.
- عرض المواعيد ومتابعة حالاتها.
- تسجيل حضور المراجع.
- إلغاء الموعد.
- تسجيل عدم الحضور.
- البحث في المواعيد.
- فحص إشغال المواعيد في واجهة الحجز التفصيلية.
- متابعة الزيارات المحوّلة من الطبيب.
- فتح النموذج الطبي للزيارة وطباعته.

توجد وظائف للمواعيد في أكثر من واجهة، ولذلك يحتاج التقييم المؤسسي إلى التحقق من اتساق قواعد الحجز والتحقق عبر جميع نقاط الإدخال.

## 7. التقييم التمريضي والعلامات الحيوية

توفّر وحدة التمريض واجهة للتقييم الأولي قبل الكشف، وأخرى لمتابعة العلاج.

تشمل البيانات المتاحة:

- ضغط الدم.
- النبض.
- درجة الحرارة.
- الوزن.
- الطول.
- تشبع الأكسجين.
- الحالات المزمنة.
- الملاحظات التمريضية.
- اسم الموظف ووقت التسجيل.

تتضمن الواجهة خيارات لتوثيق حالات مثل السكري وارتفاع ضغط الدم وأمراض القلب والربو وأمراض الكلى والحساسية، مع إمكانية إضافة حالات أخرى.

وتشمل وظائف متابعة العلاج تسجيل الإجراء والمواد المستخدمة والكميات، وإتمام العلاج أو إيقافه مؤقتًا واستئنافه، وحفظ سجل مرتبط بالمراجع والموظف المنفّذ.

## 8. الكشف الطبي وتوثيق الزيارة

تتيح واجهة الزيارة الحالية للطبيب توثيق عناصر الكشف وإعداد الخدمات المرتبطة به ضمن شاشة عمل مترابطة.

تشمل البيانات والوظائف:

- الشكوى والتشخيص.
- الأمراض السابقة والحالات المزمنة.
- الأدوية السابقة.
- نتائج الفحص السريري.
- العلامات الحيوية.
- الملاحظات والخطة العلاجية.
- الوصفة الدوائية.
- طلبات المختبر والأشعة.
- إجراءات علاج العيادة.
- بنود الحساب والخصم وطريقة الدفع.

يتضمن الفحص السريري مناطق مثل الرأس والرقبة، والصدر والرئتين، والأنف والأذن والحنجرة، والقلب والأوعية، والبطن، والعينين، والجلد، والأطراف والجهاز العصبي.

كما يحتوي المشروع على نموذج طبي رقمي مرتبط بالزيارة، يتيح حفظ المعلومات وعرضها وطباعتها من الواجهات المعنية.

تختلف بعض عناصر النماذج بحسب التخصص؛ ويحتاج تخصيص النظام لمؤسسة إلى مراجعة ملاءمة النماذج لكل تخصص مطلوب.

## 9. الأدوية والوصفات وعلاج العيادة

يميّز النظام تشغيليًا بين الأدوية المكتوبة في وصفة خارجية والمواد المستخدمة داخل العيادة.

**الوصفات الخارجية:** ترتبط بالمراجع والطبيب والتخصص والتشخيص، وتحتوي عناصر الأدوية والتعليمات المتاحة في النموذج. لا يؤدي تسجيل الوصفة الخارجية إلى خصم المواد من مخزون العيادة.

**علاج العيادة:** يشمل إجراءات مثل الحقن والمحاليل الوريدية والتضميد والخياطة والإجراءات المختبرية، مع إمكانية ربط تنفيذها بالتمريض والمواد المستخدمة والحساب.

يساعد هذا التنظيم على متابعة الوصفة الطبية والخدمات المنفّذة داخل العيادة كلٌّ بحسب أثره التشغيلي والمالي.

## 10. إدارة العلاجات ومعادلات الجرعات

يتضمن المشروع وحدة لتعريف العلاجات وقواعد حساب الجرعات. ويشمل تعريف العلاج الاسم والاسم العلمي والشكل الدوائي والتركيز ووحداته وحجم المحلول وطريقة الإعطاء والملاحظات.

تدعم قواعد الجرعات:

- شروط العمر والوزن.
- الحدود الدنيا والعليا ونوع شمولها.
- استخدام الوزن أو العمر أو قيمة ثابتة كأساس للحساب.
- خطوات حسابية متتابعة باستخدام الجمع والطرح والضرب والقسمة.
- تحديد وحدة النتيجة.
- تحديد جرعة واحدة أو جرعة يومية.
- تعريف الحد الأدنى والحد الأقصى للجرعة.
- تحويل الجرعة إلى حجم عند توفر بيانات تركيز متوافقة.
- إضافة القواعد وتعديلها ونسخها وتفعيلها أو تعطيلها.
- اختبار القاعدة بإدخال قيم تجريبية.
- اكتشاف تداخل القواعد أو وجود أكثر من قاعدة مطابقة.

تعرض الوحدة رسائل عند غياب مدخلات مطلوبة أو وجود قاعدة غير صالحة، وتنبيهات عند تجاوز الحدود المحددة.

يعتمد الحساب على القواعد التي يعرّفها المستخدم، ولذلك تتطلب القواعد والوحدات ونتائج الحساب مراجعة مختصة قبل اعتمادها للاستخدام السريري.

## 11. المختبر والأشعة

تدعم وحدة المختبر تسجيل طلبات الفحص وربطها بالمراجع، مع تحديد الفحوصات والأولوية والحالة والملاحظات والمعلومات السريرية.

تتضمن النماذج معلومات إضافية مثل الصيام والسكري والتدخين والأدوية وبيانات الإحالة. ويحتوي المشروع على قائمة للفحوصات مع إمكانية إضافة عناصر وفق الواجهات المتاحة.

تشمل الوظائف:

- إنشاء طلب المختبر.
- تحديد الأولوية، بما فيها الطلبات الروتينية والعاجلة.
- متابعة حالة الطلب وإدخال النتائج.
- إرفاق ملفات النتائج.
- طباعة نموذج طلب المختبر.

أما طلبات الأشعة فتتضمن نوع الفحص والمنطقة المطلوبة والأولوية والداعي السريري والحالة، مع إمكانية إعداد نموذج للطباعة.

التعامل مع ملفات النتائج يتم على مستوى الحفظ والربط والفتح؛ ولا توجد في النسخة الحالية منظومة ربط مباشر بأجهزة المختبر أو نظام أرشفة صور طبية متخصص.

## 12. الحسابات والمدفوعات

يربط النظام الجانب المالي بالمراجع والزيارة، ويوفّر بنودًا لوصف الخدمات وقيمتها ومتابعة المدفوعات.

تشمل الوظائف:

- إضافة بنود الحساب.
- تسجيل الخصم.
- حساب الإجمالي.
- تسجيل سداد كامل أو دفعة جزئية.
- متابعة الرصيد المتبقي.
- تسجيل مبلغ زائد بوصفه رصيدًا مقدمًا.
- حفظ حركة الدفع ووقتها والموظف الذي استلمها.
- عرض حالة الحساب: مدفوع أو مدفوع جزئيًا أو غير مدفوع.
- تسجيل طريقة الدفع، مثل النقد أو البطاقة أو التحويل.

تُعرض القيم المالية في مواضع عديدة بالدينار الأردني. وطرق الدفع المسجلة هي بيانات توثيقية داخل النظام؛ لا تتضمن النسخة الحالية تكاملًا مع بوابة دفع أو جهاز دفع إلكتروني.

## 13. مخزون العيادة

تتيح وحدة المخزون تعريف الأصناف وتصنيفها ومتابعة كمياتها وحركاتها.

يشمل نموذج الصنف بيانات مثل:

- الاسم والتصنيف والتصنيف الفرعي.
- الوحدة والكمية.
- المادة الفعالة والشكل الدوائي والعيار.
- الشركة المصنّعة.
- الباركود وموقع التخزين.
- رقم التشغيلة وتاريخ الصلاحية.
- المورد وسعر الشراء وسعر البيع.
- حد إعادة الطلب.
- التخصصات المسموح لها باستخدام الصنف.
- حالة التفعيل والملاحظات.

تشمل الوظائف إضافة الأصناف وتعديلها وإضافة المخزون وتسجيل الصرف وربطه بالمراجع والموظف والتخصص.

يتحقق النظام قبل الصرف من وجود الصنف وتفعيله وتوفر الكمية وملاءمة التخصص. ويسجل حركة المخزون، ويُنشئ تنبيهًا عند انخفاض الكمية إلى حد إعادة الطلب في الحالات المطبّقة بالكود.

وجود حقل للباركود يدعم تخزين قيمته، ولا يعني وجود تكامل مستقل مع قارئ باركود أو جهاز مخزون.

## 14. الإدارة والتقارير

توفّر لوحة الإدارة مؤشرات عن المراجعين والأطباء والمواعيد والمخزون والحركات التشغيلية والمالية.

كما تتضمن إدارة بيانات مرتبطة بـ:

- الأقسام.
- الخدمات وأسعارها.
- الموردين.
- المشتريات.
- المصروفات.
- سجل إجراءات إدارية.

تتيح التقارير عرض ملخصات بحسب الفترة والتخصص، وتشمل أعداد المراجعين والزيارات والمواعيد، وحالات طلبات المختبر، والوصفات، والأرصدة المستحقة، والمبالغ المحصلة والإيرادات اليومية.

وتشمل مؤشرات المخزون الأصناف المنخفضة والنافدة والقيمة التقديرية للشراء، كما توجد ملخصات للمرفقات وأحجام الملفات.

يمثل سجل الإجراءات توثيقًا لبعض العمليات التي يسجلها التطبيق؛ ولا يشمل بالضرورة جميع الأحداث، ولا يُقدَّم بوصفه سجل تدقيق محصّنًا من التعديل.

## 15. الملفات والإجازات المرضية والطباعة

يدعم النظام حفظ المرفقات وربطها بالمراجع أو طلب المختبر أو ملفات العيادة. ويحتفظ ببيانات الملف، مثل الاسم والمسار والامتداد والحجم وتاريخ الإضافة.

تتيح واجهة اختيار النتائج إرفاق ملفات PDF وصور ومستندات Word وExcel وملفات نصية وغيرها. ويستخدم النظام التطبيقات المرتبطة بالامتدادات لفتح الملفات؛ لا يتضمن محرّرًا داخليًا كاملًا لهذه الصيغ.

تتيح وحدة الإجازات المرضية تسجيل بيانات مثل تاريخ البداية وعدد الأيام وتاريخ المراجعة والشكوى والفحص والتشخيص وتوصية الراحة وبيانات الطبيب، مع إعداد نموذج للطباعة.

يعتمد إعداد النماذج الطبية على أدوات المستندات والطباعة في WPF. ويمكن حفظ النماذج بصيغة PDF باستخدام طابعة PDF المتاحة في Windows، دون اعتبار ذلك محرك تصدير PDF مستقلًا داخل المشروع.

## 16. التسجيل الصوتي والذكاء الاصطناعي

يدعم النظام بدء التسجيل الصوتي وإيقافه مؤقتًا واستئنافه وحفظه بصيغة WAV، وربطه بالمراجع مع وقت التسجيل ومدته. كما تتوفر وظائف لتشغيل التسجيلات وتنزيل نسخة منها.

يعتمد التسجيل على واجهة Windows الصوتية `winmm.dll` من خلال الاستدعاء البرمجي باستخدام `P/Invoke`.

يتضمن المشروع تكاملين اختياريين مع OpenAI:

**تحويل الصوت إلى نص:** إرسال ملف التسجيل إلى خدمة التفريغ الصوتي، مع تحديد العربية واستقبال النص الناتج.

**تحليل نص التشخيص:** إرسال نص التشخيص الذي أدخله الطبيب إلى خدمة تحليل نصي، وعرض الاستجابة بوصفها مساعدة للطبيب.

لا تجمع خدمة تحليل التشخيص تلقائيًا حقول هوية المراجع أو العلامات الحيوية أو بقية بيانات الزيارة. ومع ذلك، يُرسل النص المدخل نفسه؛ فإذا تضمّن معلومات شخصية كتبها المستخدم، فلا توجد في الخدمة آلية مستقلة لإزالتها تلقائيًا.

تُقرأ مفاتيح الوصول وإعدادات النماذج من متغيرات البيئة. وتتطلب هذه الوظائف اتصالًا بالإنترنت ومفتاحًا صالحًا ونموذجًا متاحًا لدى مزوّد الخدمة. لم يشمل التحقق السابق تنفيذ طلبات فعلية لهذه الخدمات.

## 17. اللغات والأطر والمكتبات

| التقنية | استخدامها في المشروع |
|---|---|
| **C#** | منطق التطبيق، نماذج البيانات، الخدمات، معالجة الأحداث والحسابات |
| **XAML** | تعريف واجهات WPF والتنسيقات والقوالب والموارد |
| **.NET 10** | إطار التشغيل الأساسي للتطبيق، بهدف `net10.0-windows` |
| **WPF** | النوافذ وعناصر الواجهة وربط البيانات والطباعة والحركات البصرية |
| **Windows Forms** | واجهة المثبّت المرفق |
| **.NET Framework 4.x** | تشغيل المثبّت المبني بأدوات Windows المتوفرة |
| **PowerShell** | بناء حزمة التثبيت وتنفيذ إزالة الملفات المثبتة |
| **JSON** | تخزين البيانات والإعدادات وتبادل طلبات واستجابات الخدمات |
| **Markdown** | ملفات التعريف والتوثيق المرفقة بالمصدر |

تعتمد النسخة الأساسية على مكتبات .NET المدمجة. لا يحتوي ملف المشروع الحالي على مراجع لحزم NuGet خارجية.

أبرز المكتبات وواجهات النظام المستخدمة:

- **System.Text.Json:** تحويل نماذج البيانات إلى JSON وقراءتها.
- **System.Net.Http:** تنفيذ طلبات HTTP للخدمات الخارجية.
- **System.Net.Http.Headers:** إعداد ترويسات المصادقة والمحتوى.
- **System.IO:** التعامل مع الملفات والمجلدات والمرفقات.
- **System.Linq:** البحث والتصفية والتجميع والحسابات على مجموعات البيانات.
- **System.Threading وSystem.Threading.Tasks:** العمليات غير المتزامنة والإلغاء والمهام.
- **System.Windows.Controls:** عناصر واجهة WPF.
- **System.Windows.Media وSystem.Windows.Media.Animation:** التنسيق والحركات البصرية.
- **System.Windows.Documents:** بناء مستندات ونماذج الطباعة.
- **System.Media:** تشغيل المؤثرات والتسجيلات الصوتية.
- **System.Runtime.InteropServices:** الاستدعاء المباشر لواجهات Windows.
- **System.IO.Compression:** ضغط حزمة التشغيل وفك ملفات المثبّت.
- **Microsoft.Win32:** حوارات الملفات وتسجيل بيانات إزالة التطبيق.
- **System.Drawing:** عناصر الرسم والخطوط المرتبطة بالمثبّت والأيقونة.
- **WScript.Shell عبر COM:** إنشاء اختصارات التطبيق.

يوجد أيضًا كود مساعد لـPBKDF2-SHA256 ضمن المصدر، لكنه لا يُستخدم في النسخة الحالية لتجزئة كلمات مرور حسابات تسجيل الدخول.

## 18. البنية البرمجية

يتوزع المشروع على مكونات رئيسية:

| المكوّن | المسؤولية |
|---|---|
| **Models** | تعريف المراجع والزيارة والمواعيد والوصفات والمخزون والحسابات وغيرها |
| **Views** | الواجهات المرئية وملفات معالجة أحداثها |
| **Services** | التخزين والمخزون وحساب الجرعات والطباعة والتسجيل والتكامل الخارجي |
| **MainWindow** | التنقل وإدارة الجلسة وربط أحداث الوحدات |
| **Assets** | الأيقونة والموارد الصوتية والبصرية |
| **Installer** | مصدر المثبّت وبرنامج البناء وإزالة التطبيق |

تعتمد الواجهات على **XAML مع Code-behind**، مع فصل نماذج البيانات وبعض الخدمات عن الواجهة. ولا تعتمد النسخة الحالية تطبيقًا كاملًا لنمط MVVM أو طبقة مستقلة لكل منطق الأعمال.

تستخدم المكونات أحداثًا لنقل طلبات مثل فتح ملف مراجع أو تسجيل دفعة أو إنهاء زيارة، وتتولى النافذة الرئيسية تنسيق عدد من هذه العمليات.

## 19. التخزين والتشغيل المشترك

تُحفظ البيانات في ملف JSON باسم `mediflow-data.json`. وتشمل لقطة البيانات المراجعين والزيارات والمواعيد والفحوصات والوصفات والحسابات والمخزون والحسابات المستخدمة وغيرها.

تستخدم النسخة التجريبية مجلدًا منفصلًا باسم `ShifaDemo` داخل بيانات المستخدم المحلية، ويمكن تحديد مجلد مخصص بواسطة متغير البيئة `SHIFA_DEMO_DATA_DIR`.

تدعم الخدمة إعداد مجلد مشترك على الشبكة. ويتضمن التنفيذ:

- حفظ مسار المجلد في إعدادات محلية.
- التحقق من الوصول إليه.
- استخدام ملف قفل أثناء الحفظ.
- الكتابة إلى ملف مؤقت ثم استبدال ملف البيانات.
- متابعة وقت تعديل الملف وحجمه.
- فحص التغييرات الخارجية دوريًا أثناء التشغيل.

هذه الآليات تدعم مشاركة الملفات، لكنها لا توفر معاملات قاعدة بيانات أو دمجًا كاملًا للتعديلات المتزامنة. ولذلك يحتاج تشغيل عدة مستخدمين في الوقت نفسه إلى اختبارات إضافية ومعالجة احتمال الكتابة فوق تغييرات جلسة أخرى.

لا تستخدم النسخة الحالية SQL Server أو SQLite أو PostgreSQL، ولا تعتمد خادم تطبيقات مركزيًا.

</div>

----------------------------------------------------------------------------------------------------------------------------------------------------------------------

## English a description :

# Functional and Technical Overview of the Shifa Project

**Project Name:** Shifa — شفاء  
**Version Covered:** 1.0.2  
**System Type:** A desktop application for clinic management and the coordination of clinical, administrative, and financial workflows.  
**Target Operating Environment:** Windows 10 and Windows 11, 64-bit architecture.  
**Developer:** Ali Ragheb Al-Aidi  
**Developer’s GitHub Profile:** https://github.com/aliabnaidi

## 1. Project Overview

Shifa is a desktop system designed to organize daily clinic operations by connecting patient registration, nursing assessment, medical examination, billing, and treatment delivery within a single workflow.

The system provides interfaces for physicians, clinic staff, and management. It maintains interconnected records of patient information, visits, appointments, prescriptions, diagnostic tests, attachments, and financial transactions. It also includes clinic inventory management, configurable dosage calculation rules, audio recording, and optional integration with artificial intelligence services.

The current version supports three primary specialties: general medicine, dentistry, and gynecology. The application operates locally and allows a shared folder to be configured for exchanging data between clinic computers.

## 2. Project Objectives and Operational Value

The project aims to achieve the following practical objectives:

- Organize patient movement between reception, nursing, physicians, and billing.
- Consolidate patient-related clinical and administrative information into a searchable record.
- Reduce repeated data entry across departments.
- Document visits, procedures, prescriptions, and diagnostic requests.
- Track outstanding amounts, payments, and account balances.
- Monitor clinic inventory and record stock additions and consumption.
- Provide indicators and reports that support operational oversight.
- Facilitate the preparation and printing of medical forms.
- Support audio documentation and optional speech-to-text conversion.

These capabilities provide a foundation for evaluating the system in an actual work environment and measuring its effect on workflow efficiency and documentation accuracy following appropriate operational testing.

## 3. Users and Roles

The system includes accounts for physicians, management, and clinic staff, with the user experience adapted to each role.

| Role | Scope of Use |
|---|---|
| Physician | Medical examinations, patient record review, visit documentation, prescriptions, diagnostic tests, and procedures |
| Management | Oversight of operational indicators, departments, services, inventory, suppliers, purchases, and expenses |
| Reception | Patient registration, appointment scheduling, attendance tracking, and referral follow-up |
| Nursing | Initial assessment, vital sign recording, treatment monitoring, and treatment delivery |
| Accounting | Payment recording and account balance tracking |
| Unified Clinic Team | Access to nursing, reception, and accounting functions according to assigned permissions |

Staff account settings determine access to nursing, reception, and accounting functions. The staff portal displays the functions available to each account, while the interface restricts staff accounts from accessing physician pages.

In the current demonstration version, additional passwords for departments and settings have been removed, while account login and role-based permissions remain in place.

## 4. Clinic Workflow

The system follows an operational workflow that begins with patient registration and concludes with the completion of services associated with the visit:

1. **Reception:** Register a new patient or select an existing record, then assign the specialty and physician.
2. **Initial Nursing Assessment:** Enter vital signs, chronic conditions, and nursing notes.
3. **Medical Examination:** Document the presenting complaint, examination findings, diagnosis, and treatment plan.
4. **Service Preparation:** Add prescriptions, laboratory and radiology requests, in-clinic treatments, and billing items.
5. **Referral and Handoff:** Transfer relevant information to reception and nursing staff.
6. **Financial Follow-Up:** Record payments, outstanding amounts, or advance credits.
7. **Treatment Delivery:** Track treatment procedures and document materials consumed from inventory.
8. **Archiving:** Save information within the patient and visit records.

The data model includes timestamps for several stages, such as patient arrival, the start of nursing assessment, referral, payment, treatment handoff, and completion. These timestamps support tracking the sequence of activities.

## 5. Patient Management and Medical Records

The system provides a patient record that combines demographic, clinical, and administrative information. Available fields include the patient’s name, record number, age, sex, date of birth, contact numbers, email address, national identification number, address, occupation, and marital status.

The record also includes information about the specialty, physician, visit type, allergies, chronic conditions, blood group, insurance, emergency contact, and notes.

Patient record functions include:

- Registering patients and updating their information.
- Searching for patient records.
- Suggesting existing records during registration.
- Reviewing the patient’s associated history.
- Searching history entries and filtering them by category.
- Viewing previous visit details.
- Adding clinical notes.
- Accessing audio recordings linked to the patient.
- Starting a new visit from the patient record.

Data relationships use identifiers for patients, visits, and associated records, including diagnostic requests, prescriptions, and payments.

## 6. Appointments and Reception

The reception module supports patient registration and appointment scheduling, with appointments linked to a specialty and physician. Appointment records include the date, time, appointment type, status, duration, and notes.

Functions include:

- Booking an appointment for an existing patient or entering appointment information.
- Selecting the specialty and physician.
- Viewing appointments and tracking their status.
- Recording patient attendance.
- Cancelling appointments.
- Recording non-attendance.
- Searching appointments.
- Checking occupied appointment slots in the detailed booking interface.
- Following up on visits referred by physicians.
- Opening and printing the medical visit form.

Appointment functions are available through more than one interface. Institutional evaluation should therefore verify that booking and validation rules operate consistently across all entry points.

## 7. Nursing Assessment and Vital Signs

The nursing module provides an interface for the initial assessment before medical examination and another for treatment follow-up.

Available information includes:

- Blood pressure.
- Pulse.
- Temperature.
- Weight.
- Height.
- Oxygen saturation.
- Chronic conditions.
- Nursing notes.
- Staff member name and recording time.

The interface provides options for documenting conditions such as diabetes, hypertension, heart disease, asthma, kidney disease, and allergies, with the ability to enter additional conditions.

Treatment follow-up functions include recording procedures, materials used, and quantities; completing treatment; pausing and resuming treatment; and maintaining a record linked to the patient and the staff member who performed the procedure.

## 8. Medical Examination and Visit Documentation

The current visit interface enables physicians to document examination details and prepare associated services within an integrated workspace.

Available information and functions include:

- Presenting complaint and diagnosis.
- Previous illnesses and chronic conditions.
- Previous medications.
- Clinical examination findings.
- Vital signs.
- Notes and treatment plan.
- Medication prescriptions.
- Laboratory and radiology requests.
- In-clinic treatment procedures.
- Billing items, discounts, and payment method.

Clinical examination sections cover areas such as the head and neck, chest and lungs, ear, nose and throat, cardiovascular system, abdomen, eyes, skin, limbs, and nervous system.

The project also includes a digital medical form associated with the visit. This form allows information to be saved, displayed, and printed through the relevant interfaces.

Some form elements vary by specialty. Customizing the system for an institution requires reviewing the suitability of the forms for each required specialty.

## 9. Medications, Prescriptions, and In-Clinic Treatment

The system makes an operational distinction between medications prescribed for purchase from an external pharmacy and materials used within the clinic.

**External Prescriptions:** These are linked to the patient, physician, specialty, and diagnosis and contain medication items and the instructions supported by the form. Recording an external prescription does not deduct items from clinic inventory.

**In-Clinic Treatment:** This includes procedures such as injections, intravenous fluids, dressings, suturing, and laboratory procedures. Treatment delivery can be linked to nursing staff, materials used, and billing.

This structure supports tracking prescriptions and services delivered within the clinic according to their respective operational and financial effects.

## 10. Treatment Management and Dosage Formulas

The project includes a module for defining treatments and dosage calculation rules. Treatment definitions include the name, generic name, dosage form, concentration and units, solution volume, route of administration, and notes.

Dosage rules support:

- Age and weight conditions.
- Lower and upper limits, including whether boundary values are included.
- Using weight, age, or a fixed value as the calculation basis.
- Sequential arithmetic steps using addition, subtraction, multiplication, and division.
- Defining the result unit.
- Specifying a single dose or daily dose.
- Defining minimum and maximum dosage limits.
- Converting a calculated dose into a volume when compatible concentration data is available.
- Adding, editing, duplicating, enabling, or disabling rules.
- Testing a rule using sample inputs.
- Detecting overlapping rules or multiple matching rules.

The module displays messages when required inputs are missing or a rule is invalid, and warnings when defined limits are exceeded.

Calculations depend on user-defined rules. The rules, units, and calculation results therefore require specialist review before they are approved for clinical use.

## 11. Laboratory and Radiology

The laboratory module supports recording test requests and linking them to patients, including the requested tests, priority, status, notes, and clinical information.

The forms include additional information such as fasting status, diabetes, smoking, medications, and referral details. The project includes a test catalogue, with the ability to add entries through the available interfaces.

Functions include:

- Creating laboratory requests.
- Setting priorities, including routine and urgent requests.
- Tracking request status and entering results.
- Attaching result files.
- Printing laboratory request forms.

Radiology requests include the examination type, requested body region, priority, clinical indication, and status, with the ability to prepare a printable form.

Result files are stored, linked, and opened through the application. The current version does not include direct integration with laboratory equipment or a dedicated medical image archiving system.

## 12. Accounts and Payments

The system links financial information to patients and visits and provides billing items for describing services, recording their value, and tracking payments.

Functions include:

- Adding billing items.
- Recording discounts.
- Calculating totals.
- Recording full or partial payments.
- Tracking outstanding balances.
- Recording excess payments as advance credits.
- Saving payment transactions, timestamps, and the receiving staff member.
- Displaying account status as paid, partially paid, or unpaid.
- Recording payment methods such as cash, card, or bank transfer.

Financial values are displayed in Jordanian dinars in many parts of the application. Recorded payment methods are documentation fields within the system; the current version does not integrate with a payment gateway or electronic payment terminal.

## 13. Clinic Inventory

The inventory module allows items to be defined and classified and their quantities and movements to be tracked.

The inventory item model includes information such as:

- Name, category, and subcategory.
- Unit and quantity.
- Active ingredient, dosage form, and strength.
- Manufacturer.
- Barcode and storage location.
- Batch number and expiry date.
- Supplier, purchase price, and sale price.
- Reorder threshold.
- Specialties permitted to use the item.
- Active status and notes.

Functions include adding and editing items, adding stock, recording consumption, and linking stock movements to the patient, staff member, and specialty.

Before consumption is recorded, the system checks that the item exists, is active, has sufficient stock, and is permitted for the specialty. It records the inventory movement and generates an alert when stock reaches the reorder threshold under the conditions implemented in the code.

The barcode field supports storing a barcode value. Its presence does not indicate a separate integration with a barcode scanner or inventory device.

## 14. Management and Reporting

The management dashboard provides indicators related to patients, physicians, appointments, inventory, and operational and financial transactions.

It also supports managing information associated with:

- Departments.
- Services and their prices.
- Suppliers.
- Purchases.
- Expenses.
- An administrative activity log.

Reports display summaries by period and specialty. These include patient, visit, and appointment counts; laboratory request statuses; prescriptions; outstanding balances; collected payments; and daily revenue.

Inventory indicators include low-stock and out-of-stock items and estimated purchase value. Summaries are also available for attachments and file sizes.

The activity log documents selected operations recorded by the application. It does not necessarily cover every event and is not presented as a tamper-resistant audit trail.

## 15. Files, Medical Leave Certificates, and Printing

The system supports storing attachments and linking them to patients, laboratory requests, or clinic files. It retains file information such as the name, path, extension, size, and date added.

The result-file selection interface supports attaching PDFs, images, Word documents, Excel files, text files, and other formats. The system opens files using the applications associated with their extensions; it does not include a complete internal editor for these formats.

The medical leave module records information such as the start date, number of days, follow-up date, presenting complaint, examination findings, diagnosis, rest recommendation, and physician details, and prepares a printable form.

Medical forms are prepared using WPF document and printing tools. Forms can be saved as PDFs through a PDF printer available in Windows. This does not constitute a dedicated PDF export engine within the project.

## 16. Audio Recording and Artificial Intelligence

The system supports starting, pausing, resuming, and saving audio recordings in WAV format. Recordings are linked to patients and include the recording time and duration. Functions are also available for playback and downloading a copy.

Audio recording uses the Windows audio interface `winmm.dll`, accessed programmatically through `P/Invoke`.

The project includes two optional integrations with OpenAI:

**Speech-to-Text Conversion:** Sends the recording file to a transcription service, specifies Arabic as the language, and receives the resulting text.

**Diagnosis Text Analysis:** Sends the diagnosis text entered by the physician to a text analysis service and displays the response as assistance for the physician.

The diagnosis analysis service does not automatically collect patient identity fields, vital signs, or other visit information. However, it sends the entered text itself. If the user includes personal information in that text, the service does not provide a separate mechanism for automatically removing it.

API keys and model settings are read from environment variables. These functions require an internet connection, a valid API key, and a model available from the service provider. Previous verification did not include submitting live requests to these services.

## 17. Languages, Frameworks, and Libraries

| Technology | Use in the Project |
|---|---|
| **C#** | Application logic, data models, services, event handling, and calculations |
| **XAML** | Definition of WPF interfaces, styles, templates, and resources |
| **.NET 10** | Primary application runtime framework, targeting `net10.0-windows` |
| **WPF** | Windows, interface controls, data binding, printing, and visual animations |
| **Windows Forms** | Interface for the supplied installer |
| **.NET Framework 4.x** | Execution of the installer built using available Windows tools |
| **PowerShell** | Building the installation package and removing installed files |
| **JSON** | Storing data and settings and exchanging service requests and responses |
| **Markdown** | Project information and documentation included with the source code |

The core application uses built-in .NET libraries. The current project file does not reference external NuGet packages.

Key libraries and system interfaces include:

- **System.Text.Json:** Serializing data models to JSON and deserializing them.
- **System.Net.Http:** Performing HTTP requests to external services.
- **System.Net.Http.Headers:** Configuring authentication and content headers.
- **System.IO:** Working with files, directories, and attachments.
- **System.Linq:** Searching, filtering, grouping, and calculating across data collections.
- **System.Threading and System.Threading.Tasks:** Asynchronous operations, cancellation, and tasks.
- **System.Windows.Controls:** WPF interface controls.
- **System.Windows.Media and System.Windows.Media.Animation:** Visual styling and animations.
- **System.Windows.Documents:** Building documents and printable forms.
- **System.Media:** Playing sound effects and audio recordings.
- **System.Runtime.InteropServices:** Direct calls to Windows interfaces.
- **System.IO.Compression:** Compressing the application package and extracting installer files.
- **Microsoft.Win32:** File dialogs and application uninstallation registration.
- **System.Drawing:** Drawing and font components associated with the installer and icon.
- **WScript.Shell through COM:** Creating application shortcuts.

The source code also contains a PBKDF2-SHA256 helper. However, the current version does not use it to hash login account passwords.

## 18. Software Architecture

The project is organized into the following main components:

| Component | Responsibility |
|---|---|
| **Models** | Definitions for patients, visits, appointments, prescriptions, inventory, accounts, and other records |
| **Views** | Visual interfaces and their event-handling code |
| **Services** | Storage, inventory, dosage calculations, printing, recording, and external integration |
| **MainWindow** | Navigation, session management, and coordination of module events |
| **Assets** | The application icon and audio and visual resources |
| **Installer** | Installer source code, build script, and application removal script |

The interfaces use **XAML with code-behind**, with data models and selected services separated from the interface. The current version does not implement a complete MVVM architecture or a separate layer for all business logic.

Components use events to communicate requests such as opening a patient record, recording a payment, or completing a visit. The main window coordinates a number of these operations.

## 19. Data Storage and Shared Operation

Data is stored in a JSON file named `mediflow-data.json`. The data snapshot includes patients, visits, appointments, diagnostic requests, prescriptions, financial records, inventory, user accounts, and other information.

The demonstration version uses a separate folder named `ShifaDemo` within the user’s local application data. A custom folder can be specified through the `SHIFA_DEMO_DATA_DIR` environment variable.

The storage service supports configuring a shared network folder. Its implementation includes:

- Saving the folder path in local settings.
- Checking access to the folder.
- Using a lock file during saving.
- Writing to a temporary file before replacing the data file.
- Monitoring the data file’s modification time and size.
- Periodically checking for external changes while the application is running.

These mechanisms support file sharing, but they do not provide database transactions or complete merging of concurrent changes. Simultaneous operation by multiple users therefore requires further testing and measures to address the possibility of one session overwriting another session’s changes.

The current version does not use SQL Server, SQLite, or PostgreSQL and does not rely on a centralized application server.
