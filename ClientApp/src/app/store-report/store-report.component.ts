import { AfterViewChecked, Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpParams, HttpClient} from "@angular/common/http";
import { HttpService } from 'src/app/http.service';
import { ReportByNet } from 'src/app/reportbynet';
import { NGXLogger } from 'ngx-logger';
import { AfterViewInit, ViewChild, OnInit } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatTable } from '@angular/material/table';



@Component({
    selector: 'app-store-report',
    templateUrl: './store-report.component.html',
    styleUrls: ['./store-report.component.css'],    
      providers: [HttpService]

})
/** StoreReport component*/
export class StoreReportComponent implements AfterViewChecked {
  report: ReportByNet[];
  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ['storeName', 'ordersCount', 'soldOrders',
    'timeOutCanceled', 'customerCanceledOrders', 'noEndStatusOrd', 'canceledOrd', 'noReceiveStatusOrd'];
  start: string;
  end: string;
  params: HttpParams;
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  @ViewChild(MatSort) sort: MatSort;


  ngAfterViewChecked() {
    this.dataSource.sort = this.sort;
  }

  /** StoreReport ctor */
  constructor(private httpService: HttpService, private logger: NGXLogger, private http: HttpClient) {

  }

  makeFloor(num: number) {
    return Math.floor(num);
  }

  loadReport() {
    if (this.range.value.start == null || this.range.value.end == null) {

    }
    this.start = this.range.value.start;
    this.end = this.range.value.end;
    this.params = new HttpParams().set('start', this.start).set('end', this.end);

    this.httpService.GetReportForStores(this.params)
      .subscribe((data: ReportByNet[]) => {
        this.report = data,
          this.dataSource = new MatTableDataSource<ReportByNet>(data);       
        error => console.error(error)
      });
    
    
    
  }  
}


export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
  symbol2: string;

}

//const ELEMENT_DATA: PeriodicElement[] = [
//  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
//  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
//  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
//  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
//  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
//  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
//  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
//  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
//  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
//  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
//];

const ELEMENT_DATA2: PeriodicElement[] = [
  { position: 0, name: 'Hydrogen', weight: 1.0079, symbol: 'H', symbol2: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He', symbol2: 'H'  },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li', symbol2: 'H'  },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be', symbol2: 'H'  },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B', symbol2: 'H'  },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C', symbol2: 'H'  },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N', symbol2: 'H'  },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O', symbol2: 'H'  },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F', symbol2: 'H'  },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne', symbol2: 'H'  },
];

let DATA: ReportByNet[] = [
  {
    "storeName": "МИЦАР ОФИС",
    "storesCount": 0,
    "ordersCount": 0,
    "soldOrders": 0,
    "timeOutCanceled": 0,
    "customerCanceledOrders": 0,
    "noEndStatusOrd": 0,
    "canceledOrd": 0,
    "noReceiveStatusOrd": 0
  },
  {
    "storeName": "МИЦАР Медведково Шокальского",
    "storesCount": 0,
    "ordersCount": 0,
    "soldOrders": 0,
    "timeOutCanceled": 0,
    "customerCanceledOrders": 0,
    "noEndStatusOrd": 0,
    "canceledOrd": 0,
    "noReceiveStatusOrd": 0
  },
  {
    "storeName": "МИЦАР Олимпийская деревня Мичуринский пр-кт ",
    "storesCount": 0,
    "ordersCount": 83,
    "soldOrders": 44,
    "timeOutCanceled": 22,
    "customerCanceledOrders": 4,
    "noEndStatusOrd": 0,
    "canceledOrd": 1,
    "noReceiveStatusOrd": 71
  },
  {
    "storeName": "МИЦАР Отрадное Санникова",
    "storesCount": 0,
    "ordersCount": 41,
    "soldOrders": 11,
    "timeOutCanceled": 14,
    "customerCanceledOrders": 0,
    "noEndStatusOrd": 0,
    "canceledOrd": 7,
    "noReceiveStatusOrd": 32
  },
  {
    "storeName": "МИЦАР Старый Гай 8 Б",
    "storesCount": 0,
    "ordersCount": 0,
    "soldOrders": 0,
    "timeOutCanceled": 0,
    "customerCanceledOrders": 0,
    "noEndStatusOrd": 0,
    "canceledOrd": 0,
    "noReceiveStatusOrd": 0
  }
]
