"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReportByNet = void 0;
var ReportByNet = /** @class */ (function () {
    function ReportByNet(storeName, storesCount, ordersCount, soldOrders, timeOutCanceled, customerCanceledOrders, noEndStatusOrd, canceledOrd, noReceiveStatusOrd) {
        this.storeName = storeName;
        this.storesCount = storesCount;
        this.ordersCount = ordersCount;
        this.soldOrders = soldOrders;
        this.timeOutCanceled = timeOutCanceled;
        this.customerCanceledOrders = customerCanceledOrders;
        this.noEndStatusOrd = noEndStatusOrd;
        this.canceledOrd = canceledOrd;
        this.noReceiveStatusOrd = noReceiveStatusOrd;
    }
    return ReportByNet;
}());
exports.ReportByNet = ReportByNet;
//# sourceMappingURL=reportbynet.js.map