import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { firstValueFrom, Observable } from 'rxjs';
import { CourseModel } from '../models/course.model';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) {}

  public async getCourses(): Promise<Observable<CourseModel[]>> {
    return this.http.get<CourseModel[]>(this.baseUrl + 'api/courses');
  }

  public async getCourse(courseId: number): Promise<CourseModel> {
    return firstValueFrom(
      this.http.get<CourseModel>(`${this.baseUrl}api/courses/${courseId}`)
    );
  }

  public async postNewCourse(course: CourseModel): Promise<boolean> {
    return firstValueFrom(
      this.http.post<boolean>(this.baseUrl + 'api/courses', course)
    );
  }

  public async putModifiedCourse(course: CourseModel): Promise<boolean> {
    return firstValueFrom(
      this.http.put<boolean>(`${this.baseUrl}api/courses/${course.id}`, course)
    );
  }

  public async deleteCourse(courseId: number): Promise<boolean> {
    return firstValueFrom(
      this.http.delete<boolean>(`${this.baseUrl}api/courses/${courseId}`)
    );
  }
}
