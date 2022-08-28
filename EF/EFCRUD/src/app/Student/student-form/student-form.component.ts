import { Component, Inject, OnInit } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { Student } from 'src/app/Model/Student';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css'],
})
export class StudentFormComponent implements OnInit {

  selItem:Student=new Student();
  selId: number = 0;
  selItems: any[] = [
    {
      id: 1,
      label: 'Salom',
    },
    {
      id: 2,
      label: 'Salom',
    },
    {
      id: 3,
      label: 'Salom',
    },
  ];

  constructor(
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) private _data: any,
    public matDialogRef: MatDialogRef<StudentFormComponent>
  ) {}

  ngOnInit() {}
  onClose(): void{
  }
  onSave():void{
  }
  onChangeModel(type: any){

  }
}
