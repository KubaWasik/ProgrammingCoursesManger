import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule, Routes } from '@angular/router';
import { CoursesComponent } from './components/courses.component';
import { DeleteCourseDialogComponent } from './components/delete-course-dialog/delete-course-dialog.component';
import { EditCourseComponent } from './components/edit-course/edit-course.component';
import { NewCourseComponent } from './components/new-course/new-course.component';
import { CoursesRoutingModule } from './courses-routing.module';

const routes: Routes = [{ path: '', component: CoursesComponent }];

@NgModule({
  declarations: [
    CoursesComponent,
    NewCourseComponent,
    EditCourseComponent,
    DeleteCourseDialogComponent,
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatGridListModule,
    MatTooltipModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatDialogModule,
    MatSnackBarModule,
    MatListModule,
    FormsModule,
    ReactiveFormsModule,
    CoursesRoutingModule,
    RouterModule.forChild(routes),
  ],
})
export class CoursesModule {}
