var navicon = navicon || {};
//Константы режима работы формы
navicon.forms.formType = (function(){
    return{
        Undefined:0,//не определено
        Create:1,//форма открывается для создания
        Update:2,//форма открывается для обновления
        ReadOnly:3,//форма открывается только для чтения
        Disabled:4,//форма заблокирована
        BulkEdit:5//форма открывается в режиме массового изменения
    };
})();

/**
 * Определить существование полей формы.
 * @param {Object}
 * @param {Array} fieldNames Массив из названий полей.
 * @returns {boolean} Результат.
 */        
navicon.forms.allFieldsDefined = function(context, fieldNames){
    if (!context) return false;
    if (!fieldNames) return true;
    let formContext = _context.getFormContext();
    let allFields=[];
    formContext.ui.controls.forEach(control => {
        allFields.push(control.getName());
    });
    return usedFields.every(t=>allFields.includes(t));
};