import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'primeng/api';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import moment from 'moment-jalaali';
moment.loadPersian({ dialect: 'persian-modern', usePersianDigits: false });

@Component({
  selector: 'app-pdf-maker',
  standalone: true,
  imports: [SharedModule, FormsModule, CommonModule],
  templateUrl: './pdf-maker.component.html',
  styleUrl: './pdf-maker.component.css'
})
export class PdfMakerComponent {
  @Input() set _patientData(value: any) {
    this.patientData = value;
    if (value) {
      const today = moment();
      const birth = moment(this.patientData.birthDate, 'jYYYY/jMM/jDD');
      this.patientData.age = today.diff(birth, 'years');
    }
  }
  patientData: any = [];
  showPdfContent = false;
  todayDate = moment().format('jYYYY/jMM/jDD');
  todayTime = moment.parseZone().local().format('HH:mm');
  get _patientData(): any {
    return this.patientData;
  }




  generatePDF(mode: 'print' | 'download') {
    document.body.style.overflow = 'hidden';
    this.showPdfContent = true;
    setTimeout(() => {
      const element = document.getElementById('pdf-content');
      if (!element) return;

      html2canvas(element, { scale: 2 }).then((canvas: HTMLCanvasElement): void => {
        const imgData = canvas.toDataURL('image/jpeg', 1.0);
        const pdf = new jsPDF('p', 'mm', 'a4');
        const pageWidth = pdf.internal.pageSize.getWidth();
        const pageHeight = pdf.internal.pageSize.getHeight();
        const imgWidth = pageWidth;
        const imgHeight = canvas.height * imgWidth / canvas.width;
        let position = 0;
        if (imgHeight <= pageHeight) {
          pdf.addImage(imgData, 'JPEG', 0, 0, imgWidth, imgHeight);
        } else {
          while (position < imgHeight) {
            pdf.addImage(imgData, 'JPEG', 0, -position, imgWidth, imgHeight);
            position += pageHeight;
            if (position < imgHeight) pdf.addPage();
          }
        }

        // pdf.save('outpatient-sheet.pdf');

        const blob = pdf.output('blob');
        const blobUrl = URL.createObjectURL(blob);
        const printWindow = window.open(blobUrl);
        if (printWindow) {
          printWindow.onload = () => {
            printWindow.focus();
            printWindow.print();
          };
        }
        document.body.style.overflow = '';
        this.showPdfContent = false;
      });
    }, 1000);

  }
}
