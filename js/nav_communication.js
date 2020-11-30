//Работа со средствами связи.
var navicon = navicon || {};
navicon.communication = (function(){
    const //Поля, которые будут использованы в этом модуле
        usedFields = ["nav_phone", "nav_email", "nav_type"],
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
        let formContext = _context.getFormContext();
        //Если режим создания формы
        if (formContext.ui.getFormType()===1){
            createEvents();//создаем события
            //Скрываем поля телефон и email
            formContext.ui.controls.get("nav_phone").setVisible(false);
            formContext.ui.controls.get("nav_email").setVisible(false);
        }
    }
    //Создать события
    function createEvents(){
        if (!_context) return;
        let formContext = _context.getFormContext();
        formContext.getAttribute("nav_type").addOnChange(()=>{
            //Скрываем поля телефон и email
            formContext.ui.controls.get("nav_phone").setVisible(false);
            formContext.ui.controls.get("nav_email").setVisible(false);
            let typeValue = formContext.getAttribute("nav_type").getValue();
            switch (typeValue) {
                case 808630001://телефон
                formContext.ui.controls.get("nav_phone").setVisible(true);
                    break;
                case 808630002://email
                    formContext.ui.controls.get("nav_email").setVisible(true);
                    break;
            }
        });
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
        
    }
    return {
        onLoad:onLoad,
        onSave:onSave
    };
})();