
export class ReportByNet {
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

  constructor(
    public storesCount: number,

    public ordersCount: number,

    public soldOrders: number,

    public timeOutCanceled: number,

    public customerCanceledOrders: number,

    public noEndStatusOrd: number,

    public canceledOrd: number,

    public noReceiveStatusOrd: number) { }
}

