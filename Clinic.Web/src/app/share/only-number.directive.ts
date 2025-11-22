import { Directive, HostListener } from '@angular/core';

@Directive({
  selector: '[OnlyNumber]',
  standalone: true 
})
export class OnlyNumberDirective {

  @HostListener('keydown', ['$event'])
  onKeyDown(event: KeyboardEvent) {
    const allowedKeys = [
      'Backspace', 'Tab', 'End', 'Home', 'ArrowLeft', 'ArrowRight', 'Delete'
    ];
    if (allowedKeys.indexOf(event.key) !== -1) {
      return; 
    }
    if (!/^[0-9]$/.test(event.key)) {
      event.preventDefault();
    }
  }
}