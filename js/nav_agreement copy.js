//Работа с договорами.
var navicon = navicon || {};
navicon.agreement = (function(){
    const 
        creditTabName="tab_credit",
        isUnaccessable = "недоступно",
        creditExpiredMessage = "Срок действия выбранной кредитной программы истек";
    var _context,
        errors=[];//здесь будем хранить ошибки
    //при загрузке формы
    function onLoad(context){
        _context = context;
        hideControls();//спрятать контролы
        hideCreditTab();//спрятать табы    
        createEvents();//создать события
    }
    //Спрятать контролы вкладки сведения
    function hideControls(){
        if (!_context) return;
        const hide = ["nav_summa", "nav_fact", "nav_creditid", "ownerid"];
        let ui = _context.getFormContext().ui;
        let controls = ui.controls.get();
        if (ui.getFormType()===1){
            controls.forEach(control => {
                if (hide.includes(control.getName())) control.setVisible(false);
            });
        }
    }
    //Спрятать вкладки
    function hideCreditTab(){
        if (!_context) return;
        let tab = _context.getFormContext().ui.tabs.get(creditTabName);
        if (tab) {tab.setVisible(false);}
            else console.error(creditTabName+" - "+isUnaccessable);
    }
    //Показать вкладку кредит и ее реквизиты
    function showCreditTab(){
        if (!_context) return;
        let tab = _context.getFormContext().ui.tabs.get(1);
        if (tab) {tab.setVisible(true);}
            else console.error(creditTabName+" - "+isUnaccessable);
    }
    //Создать события
    function createEvents(){
        if (!_context) return;
        let formContext = _context.getFormContext();
        let contact = formContext.getAttribute("nav_contact");
        let auto = formContext.getAttribute("nav_autoid");
        let credit = formContext.getAttribute("nav_creditid");
        let date = formContext.getAttribute("nav_date");
        contact.addOnChange(onConactOrAutoChanged);
        auto.addOnChange(onConactOrAutoChanged);
        credit.addOnChange(showExtraControls);//показать дополнительные контролы и вкладки
        credit.addOnChange(checkCreditExpired);//проверить кредитную программу на актуальность
        credit.addOnChange(fillCreditPeriod);//заполнить срок кредита из кредитной программы
        date.addOnChange(checkCreditExpired);//проверить кредитную программу на актуальность
        //Преобразуем номер договора к соответствующему формату (цифры и тире)
        formContext.getAttribute("nav_name").addOnChange(()=>{
            let nameValue = formContext.getAttribute("nav_name").getValue();
            if (!nameValue) return;
            nameValue=nameValue.replace(/[^\d-]/g, "");
            formContext.getAttribute("nav_name").setValue(nameValue);
        });
    }
    /**
     * Заполняет срок кредита из выбранной кредитной программы.
     * @returns {void}
     */
    function fillCreditPeriod(){
        //1. Если контекст не существует
        if (!_context) return;
        var formContext = _context.getFormContext();
        getCreditPeriod()
        .then(period=>{
            formContext.getAttribute("nav_creditperiod").setValue(period);
        });
    }
    /**
     * Получить срок кредита из кредитной программы.
     * @returns {Promise} Промис.
     */
    function getCreditPeriod(){
        return new Promise(((resolve, reject)=>{
            //1. Если контекст не существует
            if (!_context) resolve(null);
            let formContext = _context.getFormContext();
            //2. Получаем значение выбранной кредитной программы
            let creditValue = formContext.getAttribute("nav_creditid").getValue();
            //2. Если кредитная программа не выбрана
            if (creditValue===null) resolve(null);
            //3. Получаем запись кредитной программы
            Xrm.WebApi.retrieveRecord(creditValue[0].entityType, creditValue[0].id, "?$select=nav_creditperiod")
            .then(data=>{
            //3. Проверяем все необходимые для корректной работы объекты и данные
            if (typeof data==="undefined" || 
                typeof data.nav_creditperiod==="undefined") resolve(null);
            resolve(data.nav_creditperiod);//возвращаем срок кредитной программы
            },
            err=>{
                reject(err);
            });
        }));
    }
    /**
     * Показать дополнительные поля и вкладки.
     * @returns {void}
     */
    function showExtraControls(){
        if (!_context) return;
        let formContext = _context.getFormContext();
        let summa = formContext.ui.controls.get("nav_summa");
        let fact = formContext.ui.controls.get("nav_fact");
        let credit = formContext.getAttribute("nav_creditid");
        var creditValue = credit.getValue();
        //Если выбрана кредитная программа
        if (creditValue){
            //показываем другие контролы
            summa.setVisible(true);
            fact.setVisible(true);
            //показываем вкладку кредит
            showCreditTab();
        }else{
            summa.setVisible(false);
            fact.setVisible(false);
            hideCreditTab();
        }
    }
    /**
     * Если кредитная программа не актуальна, выдает сообщение пользователю.
     * @returns {void}
     */
    function checkCreditExpired(){
        if (!errors) return;
        errors = errors.filter(val=>val!=creditExpiredMessage);//убираем ошибку из массива
        CreditExpired()
        .then(result=>{
            if (result){
                Xrm.Navigation.openAlertDialog(creditExpiredMessage);
                errors.push(creditExpiredMessage);//запоминаем ошибку
            } 
        });
    }
    /**
     * Проверяет, истек ли срок действия кредитной программы по отношению к дате договора.
     * @returns {Promise} Промис.
     */
    function CreditExpired(){
        return new Promise(((resolve, reject)=>{
            var result=false;
            //1. Если контекст существует
            if (!_context) resolve(false);
            let formContext = _context.getFormContext();
            let agreementDateValue = formContext.getAttribute("nav_date").getValue();
            let creditValue = formContext.getAttribute("nav_creditid").getValue();
            //2. Если дата договора и кредитная программа заполнены
            if (agreementDateValue==null || creditValue===null) resolve(false);
            //3. Получаем дату окончания кредитной программы nav_dateend
            Xrm.WebApi.retrieveRecord(creditValue[0].entityType, creditValue[0].id, "?$select=nav_dateend")
            .then(data=>{
            //3. Проверяем все необходимые для корректной работы объекты и данные
            if (typeof data==="undefined" || 
                typeof data.nav_dateend==="undefined" ||
                data.nav_dateend==null) resolve(false);
            let creditEndDateValue = data.nav_dateend;
            agreementDateValue = new Date(agreementDateValue);
            creditEndDateValue = new Date(creditEndDateValue);
            //4. Результат проверки
            result = (agreementDateValue>creditEndDateValue);
            resolve(result);
            },
            err=>{
                reject(err);
            });
        }));
    }

    //При изменении контакта или авто
    function onConactOrAutoChanged(){
        let formContext = _context.getFormContext();
        let contactValue = formContext.getAttribute("nav_contact").getValue();
        let autoValue = formContext.getAttribute("nav_autoid").getValue();
        let nav_creditid = formContext.ui.controls.get("nav_creditid");
        if (!nav_creditid){
            console.error("nav_creditid "+isUnaccessable);
            return;
        }
        if (contactValue && autoValue) nav_creditid.setVisible(true);
            else nav_creditid.setVisible(false);
    }
    //Обработчик события сохранения формы
    function onSave(context){
        let formContext = _context.getFormContext();
        formContext.ui.clearFormNotification(creditExpiredMessage);//убираем старое сообщение
        //Если переменной error не существует, блокируем сохранение.
        if (typeof errors==="undefined" || !Array.isArray(errors)) {
            context.getEventArgs().preventDefault();
            return;
        } 
        if (errors.length>0)  context.getEventArgs().preventDefault();
        errors.forEach(err=> {
            _context.getFormContext().ui.setFormNotification(err, "ERROR", err);
        });
    }
    return {
        onLoad:onLoad,
        onSave:onSave
    };
})();