import { SubjectFromComponent } from './subject-from/subject-from.component';
import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { ConfirmationService, ConfirmEventType, MessageService } from "primeng/api";

@Injectable({
  providedIn: 'root',
})
export class SubjectService {
  selItem: any;
  constructor(
    public dialog: MatDialog,
    private confirmationService: ConfirmationService,
    private messageService: MessageService){

  }
  // Edit
  public onEdit(item: any): void{
    this.selItem=item;
    this.showdialog();
  }
  // Add
  public onAdd(){
    this.selItem;//=new;
    this.showdialog();
  }
  // showdialog
  private showdialog(){
    const dialogRef = this.dialog.open(SubjectFromComponent, {
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
