//Работа с кредитной программой.
var navicon = navicon || {};
navicon.auto = (function(){
    const //Поля, которые будут использованы в этом модуле
        usedFields = ["nav_used", "nav_km", "nav_ownerscount", "nav_isdamaged"],
        contextIsNotDefined = "Объект context не опеределен",
        oneOrMoreFieldsNotFound = "Не найдено одно или несколько полей";
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
        hideControls();//прячем контролы Пробег, Количество владельцев, был в ДТП 
    }
    //Создать события
    function createEvents(){
        if (!_context) return;
        let formContext = _context.getFormContext();
        formContext.getAttribute("nav_used").addOnChange(()=>{
            let used = formContext.getAttribute("nav_used").getValue();
            if (used) showControls();
                else hideControls();
        });
    }
    //Спрятать конролы Пробег, Количество владельцев, был в ДТП 
    function hideControls(){
        if (!_context) return;
        let formContext = _context.getFormContext();
        formContext.ui.controls.get("nav_km").setVisible(false);
        formContext.ui.controls.get("nav_ownerscount").setVisible(false);
        formContext.ui.controls.get("nav_isdamaged").setVisible(false);
    }
    //Показать конролы Пробег, Количество владельцев, был в ДТП 
    function showControls(){
        if (!_context) return;
        let formContext = _context.getFormContext();
        formContext.ui.controls.get("nav_km").setVisible(true);
        formContext.ui.controls.get("nav_ownerscount").setVisible(true);
        formContext.ui.controls.get("nav_isdamaged").setVisible(true);
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
    return {
        onLoad:onLoad
    };
})();