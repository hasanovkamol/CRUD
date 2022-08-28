import { SubjectFromComponent } from './../../Subject/subject-from/subject-from.component';
import { ConfirmationService, MessageService } from 'primeng/api';
import { StudentFormComponent } from './../../Student/student-form/student-form.component';
import { SubjectComponent } from './../../Subject/Subject.component';
import { StudentComponent } from './../../Student/Student.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatToolbarModule } from '@angular/material/toolbar';

import { MessagesModule } from 'primeng/messages';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import {ToastModule} from 'primeng/toast';
import { StudentService } from 'src/app/Student/student.service';
import { SubjectService } from 'src/app/Subject/subject.service';

export const routes: Routes = [
  { path: 'student', component: StudentComponent },
  { path: 'subject', component: SubjectComponent },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatToolbarModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,

    MatInputModule,
    MatSelectModule,

    MessagesModule,
    ConfirmDialogModule,

  ],
  declarations: [StudentComponent, StudentFormComponent, SubjectComponent, SubjectFromComponent],
  providers:[StudentService, SubjectService]
})
export class MainLayoutModule {}
