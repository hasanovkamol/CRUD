import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import {
  ConfirmationService,
  ConfirmEventType,
  MessageService,
} from 'primeng/api';
import { Student } from '../Model/Student';
import { StudentFormComponent } from './student-form/student-form.component';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  selItem: Student = new Student();

  constructor(
    public dialog: MatDialog,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {}

  // Message Service actions
  // PrimaNG dialog actions
  // Loading API
  // Form Companenta

  // Edit
  public onEdit(item: any): void {
    this.selItem = item;
    this.showDialog();
  }
  // Add
  public onAdd(): void {
    this.selItem = new Student();
    this.showDialog();
  }
  //
  private showDialog() {
    const dialogRef = this.dialog.open(StudentFormComponent, {
      width: '70%',
      data: {
        item: this.selItem,
        titleDialog: 'student form companenta',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'saved') {
        // update- list
      }
    });
  }

  // Delete
  public onDelete(item: any): void {
    this.confirmationService.confirm({
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        // Yes
        this.messageService.add({
          severity: 'info',
          summary: 'Confirmed',
          detail: 'Record deleted',
        });
      },
      reject: (type: ConfirmEventType) => {
        // No
        switch (type) {
          case ConfirmEventType.REJECT:
            this.messageService.add({
              severity: 'error',
              summary: 'Rejected',
              detail: 'You have rejected',
            });
            break;
        }
      },
    });
  }
}
