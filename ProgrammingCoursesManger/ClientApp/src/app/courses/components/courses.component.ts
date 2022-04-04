import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Router } from '@angular/router';
import { NgxUiLoaderService } from 'ngx-ui-loader';
import { firstValueFrom, Observable } from 'rxjs';
import { CourseModel } from '../models/course.model';
import { CoursesService } from '../services/courses.service';
import { DeleteCourseDialogComponent } from './delete-course-dialog/delete-course-dialog.component';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
})
export class CoursesComponent implements OnInit {
  public courses: Observable<CourseModel[]> | undefined;
  public displayedColumns: string[] = ['id', 'name', 'description', 'actions'];

  @ViewChild(MatTable) private table!: MatTable<CourseModel>;

  constructor(
    private coursesService: CoursesService,
    private loader: NgxUiLoaderService,
    private router: Router,
    public dialog: MatDialog
  ) {}

  public async ngOnInit(): Promise<void> {
    this.loader.start();

    this.courses = await this.coursesService.getCourses();

    this.loader.stop();
  }

  public async addNewCourse(): Promise<void> {
    await this.router.navigate(['/courses/new']);
  }

  public async editCourse(id: number): Promise<void> {
    await this.router.navigate([`/courses/edit/${id}`]);
  }

  public async deleteCourse(id: number): Promise<void> {
    var dialogRef = this.dialog.open(DeleteCourseDialogComponent, {
      data: id,
    });

    var result: boolean | undefined = await firstValueFrom(
      dialogRef.afterClosed()
    );

    if (result === true) {
      this.loader.start();

      this.courses = await this.coursesService.getCourses();

      this.table.renderRows();

      this.loader.stop();
    }
  }
}
