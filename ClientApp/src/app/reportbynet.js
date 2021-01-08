"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReportByNet = void 0;
var ReportByNet = /** @class */ (function () {
    //public stores_count: number;
    //public orders_count: number;
    //public sold_orders: number;
    //public time_out_canceled: number;
    //public customer_canceled_orders: number;
    //public no_end_status_ord: number;
    //public canceled_ord: number;
    //public no_receive_status_ord: number
    //constructor(storesCount: number, ordersCount: number, soldOrders: number, timeOutCanceled: number, customerCanceledOrders: number,
    //  noEndStatusOrd: number, canceledOrd: number, noReceiveStatusOrd: number) {
    //  this.stores_count = storesCount;
    //  this.orders_count = ordersCount;
    //  this.sold_orders = soldOrders;
    //  this.time_out_canceled = timeOutCanceled;
    //  this.customer_canceled_orders = customerCanceledOrders;
    //  this.no_end_status_ord = noEndStatusOrd;
    //  this.canceled_ord = canceledOrd;
    //  this.no_receive_status_ord = noReceiveStatusOrd;
    //}
    function ReportByNet(storesCount, ordersCount, soldOrders, timeOutCanceled, customerCanceledOrders, noEndStatusOrd, canceledOrd, noReceiveStatusOrd) {
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