"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReportByNet = void 0;
var ReportByNet = /** @class */ (function () {
    function ReportByNet(stores_count, orders_count, sold_orders, time_out_cancele, customer_canceled_orders, no_end_status_ord, canceled_ord, no_receive_status_ord) {
        this.stores_count = stores_count;
        this.orders_count = orders_count;
        this.sold_orders = sold_orders;
        this.time_out_cancele = time_out_cancele;
        this.customer_canceled_orders = customer_canceled_orders;
        this.no_end_status_ord = no_end_status_ord;
        this.canceled_ord = canceled_ord;
        this.no_receive_status_ord = no_receive_status_ord;
    }
    return ReportByNet;
}());
exports.ReportByNet = ReportByNet;
//# sourceMappingURL=reportbynet.js.map