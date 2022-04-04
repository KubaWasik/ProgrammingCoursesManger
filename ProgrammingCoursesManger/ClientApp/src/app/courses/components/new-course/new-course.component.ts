import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TopicModel } from '../../models/topic.model';
import { CoursesService } from '../../services/courses.service';

@Component({
  templateUrl: './new-course.component.html',
  styleUrls: ['./new-course.component.css'],
})
export class NewCourseComponent {
  public newCourseForm: FormGroup = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
  });

  public topics: TopicModel[] = [];
  public newTopic: TopicModel = { id: 0, name: undefined, number: 1 };

  constructor(
    private location: Location,
    private coursesService: CoursesService,
    private snackBar: MatSnackBar
  ) {}

  public addTopic(): void {
    if (!this.newTopic.name) {
      return;
    }

    this.topics.push({
      id: 0,
      name: this.newTopic.name,
      number: this.newTopic.number,
    });

    this.topics.sort((a, b) => {
      if (a.number === b.number) {
        return (a.name ?? '') > (b.name ?? '') ? 1 : -1;
      }

      return a.number > b.number ? 1 : -1;
    });

    this.newTopic = { id: 0, name: undefined, number: this.topics.length + 1 };
  }

  public removeTopic(i: number): void {
    this.topics = this.topics.filter((_, index) => index !== i);

    this.newTopic.number = this.topics.length + 1;
  }

  public async onSubmit(): Promise<void> {
    if (this.newCourseForm.valid) {
      var result = await this.coursesService.postNewCourse({
        id: 0,
        name: this.newCourseForm.controls.name.value,
        description: this.newCourseForm.controls.description.value,
        topics: this.topics
      });

      if (result) {
        this.snackBar.open('Poprawnie dodano nowy kurs', 'Zamknij');

        this.location.back();
      } else {
        this.snackBar.open(
          'Dodawanie nowego kursu się nie powiodło, wystąpił bład po stronie serwera',
          'Zamknij'
        );
      }
    } else {
      this.snackBar.open('Dane nowego kursu są nieprawidłowe', 'Zamknij');
    }
  }

  public goBack(): void {
    this.location.back();
  }
}
