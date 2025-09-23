import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[OnlyNumber]'
})
export class OnlyNumber {

  constructor(private _el: ElementRef) {
  }

  @Input() OnlyNumber: boolean;

  @HostListener('input', ['$event']) onKeyDown(event) {
    let initalValue = this._el.nativeElement.value;
    // var charCodeZero = '۰'.charCodeAt(0);
    // this._el.nativeElement.value =  parseInt(this._el.nativeElement.value.replace(/[۰-۹]/g, function (w) {
    //     return w.charCodeAt(0) - charCodeZero;
    // }));
    //  initalValue = this._el.nativeElement.value;
    this._el.nativeElement.value = initalValue.replace(/[^0-9]*/g, '');
    if (initalValue !== this._el.nativeElement.value) {
      event.stopPropagation();
    }
  }
}

@Directive({
  selector: '[ValidNumber]'
})
export class ValidNumber {

  constructor(private _el: ElementRef) {
  }

  @Input() ValidNumber: boolean;

  @HostListener('input', ['$event']) onKeyDown(event) {
    const initalValue = this._el.nativeElement.value;
    //let firstCheck = initalValue.replace(/^0+/g, '')
    this._el.nativeElement.value = initalValue.replace(/[^0-9]*/g, '');
    if (initalValue !== this._el.nativeElement.value) {
      event.stopPropagation();
    }
  }
}

