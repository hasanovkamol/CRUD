import { Component, OnInit } from '@angular/core';
import { StudentService } from './student.service';

@Component({
  selector: 'app-Student',
  templateUrl: './Student.component.html',
  styleUrls: ['./Student.component.scss'],
})
export class StudentComponent implements OnInit {
  constructor(public studentService: StudentService,
  ) {}

  ngOnInit() {}

}
