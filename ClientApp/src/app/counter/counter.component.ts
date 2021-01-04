import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });

  public incrementCounter() {
    this.currentCount++;
  }
}
