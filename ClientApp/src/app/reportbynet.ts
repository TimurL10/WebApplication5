export class ReportByNet {
  constructor(
        public stores_count: number,

        public orders_count: number,

        public sold_orders: number,

        public time_out_canceled: number,

        public customer_canceled_orders: number,

        public no_end_status_ord: number,

        public canceled_ord: number,

        public no_receive_status_ord: number
  ) {}
}
