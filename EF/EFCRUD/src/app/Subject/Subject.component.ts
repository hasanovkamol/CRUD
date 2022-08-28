import { Component, OnInit } from '@angular/core';
import { SubjectService } from './subject.service';

@Component({
  selector: 'app-Subject',
  templateUrl: './Subject.component.html',
  styleUrls: ['./Subject.component.scss'],
})
export class SubjectComponent implements OnInit {
  constructor(public subjectService: SubjectService) {}

  ngOnInit() {}
}
