//Работа с моделями.
var navicon = navicon || {};
navicon.model = (function(){
    const //Поля, которые будут использованы в этом модуле
        usedFields = [],
        contextIsNotDefined = "Объект context не опеределен",
        oneOrMoreFieldsNotFound = "Не найдено одно или несколько полей",
        saveAllowAdminOnly="Редактрирование разрешено только системному администратору";
    var _context;//контекст
    //при загрузке формы
    function onLoad(context){
        if (!context) {
            console.error(contextIsNotDefined);
            return;
        }
        _context = context;
        if (!allFieldsDefined(usedFields)){
            console.error(oneOrMoreFieldsNotFound+" "+usedFields.toString());
            return;
        }
        if (!isUserInRole("Системный администратор") && _context.getFormContext().ui.getFormType()===2){
            setAllControlsDisabled();//делаем контролы недоступными
            //выводим информационное сообщение, чтобы пользователь понимал что к чему
            _context.getFormContext().ui.setFormNotification(saveAllowAdminOnly, "INFO", saveAllowAdminOnly);
        }
    }
    /**
     * Сделать недоступными все контролы формы.
     * @returns {void}
     */
    function setAllControlsDisabled(){
        if (!_context) return;
        _context.getFormContext().ui.controls.get().forEach(control=>control.setDisabled(true));
    }
    /**
     * Проверяет принадлежность пользователя к роли.
     * @param {string} roleName Название роли. 
     */
    function isUserInRole(roleName){
        var roles = Xrm.Utility.getGlobalContext().userSettings.roles;
        roles.forEach(role=>{
            if (role.name===roleName) return true;
        });
        return false;
    }

    /**
     * Определить существование полей формы.
     * @param {Array} fieldNames Массив из названий полей.
     * @returns {boolean} Результат.
     */
    function allFieldsDefined(fieldNames){
        if (!_context) return false;
        if (!fieldNames) return true;
        let formContext = _context.getFormContext();
        let allFields=[];
        formContext.ui.controls.forEach(control => {
            allFields.push(control.getName());
        });
        return usedFields.every(t=>allFields.includes(t));
    }
    //Обработчик события сохранения формы
    function onSave(context){
        let formContext = _context.getFormContext();
        //formContext.ui.clearFormNotification(datesCompareError);
        if (!isUserInRole("Системный администратор")) context.getEventArgs().preventDefault(); 
    }
    return {
        onLoad:onLoad,
        onSave:onSave
    };
})();