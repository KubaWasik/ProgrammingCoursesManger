import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CoursesComponent } from './components/courses.component';
import { EditCourseComponent } from './components/edit-course/edit-course.component';
import { NewCourseComponent } from './components/new-course/new-course.component';

const routes: Routes = [
  { path: '', component: CoursesComponent },
  { path: 'new', component: NewCourseComponent },
  { path: 'edit/:courseId', component: EditCourseComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CoursesRoutingModule {}
