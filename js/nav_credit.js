//Работа с кредитной программой.
var navicon = navicon || {};
navicon.credit = (function(){
    const //Поля, которые будут использованы в этом модуле
        usedFields = ["nav_datestart", "nav_dateend"],
        contextIsNotDefined = "Объект context не опеределен",
        oneOrMoreFieldsNotFound = "Не найдено одно или несколько полей",
        datesCompareError = "Дата окончания должна быть больше даты начала не менее чем на один год!";
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
        createEvents();//создаем события
    }
    //Создать события
    function createEvents(){
        if (!_context) return;
        let formContext = _context.getFormContext();
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
    function onSave(context){
        let formContext = _context.getFormContext();
        formContext.ui.clearFormNotification(datesCompareError);
        let dateStart = formContext.getAttribute("nav_datestart").getValue();
        let dateEnd = formContext.getAttribute("nav_dateend").getValue();
        if (dateStart===null || dateEnd===null) return;
        dateStart = new Date(dateStart);
        dateEnd = new Date(dateEnd);
        let dateDiff = new Date(dateEnd.getTime() - dateStart.getTime());
        dateDiff = dateDiff.getUTCFullYear() - 1970;
        if (dateDiff<1) {
            formContext.ui.setFormNotification(datesCompareError, "WARNING", datesCompareError);
            context.getEventArgs().preventDefault();
        } 
    }
    return {
        onLoad:onLoad,
        onSave:onSave
    };
})();