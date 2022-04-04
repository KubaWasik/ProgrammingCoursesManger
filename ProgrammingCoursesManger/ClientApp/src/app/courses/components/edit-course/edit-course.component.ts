import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { CourseModel } from '../../models/course.model';
import { TopicModel } from '../../models/topic.model';
import { CoursesService } from '../../services/courses.service';

@Component({
  templateUrl: './edit-course.component.html',
  styleUrls: ['./edit-course.component.css'],
})
export class EditCourseComponent implements OnInit {
  public editCourseForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
  });

  public course!: CourseModel;
  public newTopic: TopicModel = { id: 0, name: undefined, number: 1 };


  constructor(
    private location: Location,
    private route: ActivatedRoute,
    private coursesService: CoursesService,
    private snackBar: MatSnackBar
  ) {}

  public async ngOnInit(): Promise<void> {
    const courseId = this.route.snapshot.params.courseId;

    this.course = await this.coursesService.getCourse(courseId);

    this.editCourseForm.controls.name.setValue(this.course.name);
    this.editCourseForm.controls.description.setValue(this.course.description);

    this.newTopic.number = this.course.topics.length + 1;
  }

  public addTopic(): void {
    if (!this.newTopic.name) {
      return;
    }

    this.course.topics.push({
      id: 0,
      name: this.newTopic.name,
      number: this.newTopic.number,
    });

    this.course.topics.sort((a, b) => {
      if (a.number === b.number) {
        return (a.name ?? '') > (b.name ?? '') ? 1 : -1;
      }

      return a.number > b.number ? 1 : -1;
    });

    this.newTopic = { id: 0, name: undefined, number: this.course.topics.length + 1 };
  }

  public removeTopic(i: number): void {
    this.course.topics = this.course.topics.filter((_, index) => index !== i);

    this.newTopic.number = this.course.topics.length + 1;
  }

  public async onSubmit(): Promise<void> {
    if (this.editCourseForm.valid) {
      var result = await this.coursesService.putModifiedCourse({
        id: this.course.id,
        name: this.editCourseForm.controls.name.value,
        description: this.editCourseForm.controls.description.value,
        topics: this.course.topics
      });

      if (result) {
        this.snackBar.open('Poprawnie edytowano kurs', 'Zamknij');

        this.location.back();
      } else {
        this.snackBar.open(
          'Edycja kursu nie powiodło się, wystąpił bład serwera',
          'Zamknij'
        );
      }
    } else {
      this.snackBar.open('Dane kursu są nieprawidłowe', 'Zamknij');
    }
  }

  public goBack(): void {
    this.location.back();
  }
}
