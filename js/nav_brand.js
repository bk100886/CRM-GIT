//Работа с моделями.
var navicon = navicon || {};
navicon.brand = (function(){
    const //Поля, которые будут использованы в этом модуле
        usedFields = [],
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
        let id = formContext.data.entity.getId().replace(/[{}]/g, "");
        var query = createQuery(id);//создаем запрос
        queryMultiple("nav_agreement", query)
        .then(entities=>{
            let resourceControl = formContext.getControl("WebResource_creditprogram").getContentWindow();
            resourceControl
            .then(function(contentWindow){
                //alert(JSON.stringify(entities));
                contentWindow.fillGrid(formContext, entities);
            },
            function(error){
                console.log(error.message);
            });
        });
    }
    
    /**
     * Подготовить запрос для получения данных Кредитная программа, Модель, Срок кредита.
     * @param {string} brandId Идентификатор брэнда.
     * @returns {string} FetchXml query
     */
    function createQuery(brandId){
        if (!brandId) return;
        const query = [
            "<fetch xmlns:generator='MarkMpn.SQL4CDS' distinct='true'>",
            "  <entity name='nav_agreement'>",
            "    <attribute name='nav_creditperiod' alias='period' />",
            "    <link-entity name='nav_auto' to='nav_autoid' from='nav_autoid' alias='nav_auto' link-type='inner'>",
            "      <link-entity name='nav_brand' to='nav_brandid' from='nav_brandid' alias='nav_brand' link-type='inner'>",
            "        <attribute name='nav_brandid' />",
            "      </link-entity>",
            "      <link-entity name='nav_model' to='nav_modelid' from='nav_modelid' alias='nav_model' link-type='inner'>",
            "        <attribute name='nav_name' alias='modelName' />",
            "        <attribute name='nav_modelid' alias='modelId' />",
            "      </link-entity>",
            "    </link-entity>",
            "    <link-entity name='nav_credit' to='nav_creditid' from='nav_creditid' alias='nav_credit' link-type='inner'>",
            "      <attribute name='nav_name' alias='creditName' />",
            "      <attribute name='nav_creditid' alias='creditId' />",
            "    </link-entity>",
            "    <filter>",
            "      <condition attribute='nav_brandid' entityname='nav_brand' operator='eq' value='@brandId' />",
            "    </filter>",
            "  </entity>",
            "</fetch>",
                ].join("");
            return query.replace("@brandId", brandId);
    }

    /**
     * Запрос множественной выборки.
     * @param {entityName} Название сущности.
     * @param {query} Запрос.
     * @returns {Promise} Промис.
     */
    function queryMultiple(entityName, query){
        return new Promise((resolve, reject)=>{
            if (!entityName || !query) reject("queryMultiple: определены не все параметры");
            Xrm.WebApi.retrieveMultipleRecords(entityName, "?fetchXml="+query)
                .then(data=>{
                    resolve(data.entities);
                },
                error=>{
                    reject(error.message);
                });
    
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
    //Обработчик события сохранения формы
    function onSave(context){
        let formContext = _context.getFormContext(); 
    }
    return {
        onLoad:onLoad,
        onSave:onSave
    };
})();