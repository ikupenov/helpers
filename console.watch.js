console = console || {};

console.watch = function (oObj, sProp) {
    sPrivateProp = "$_" + sProp + "_$";
    oObj[sPrivateProp] = oObj[sProp];

    Object.defineProperty(oObj, sProp, {
        get: function () {
            return oObj[sPrivateProp];
        },

        set: function (value) {
            debugger;
            oObj[sPrivateProp] = value;
        }
    });
}
