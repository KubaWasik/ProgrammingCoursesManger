import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CoursesService } from '../../services/courses.service';

@Component({
  templateUrl: './delete-course-dialog.component.html',
  styleUrls: ['./delete-course-dialog.component.css'],
})
export class DeleteCourseDialogComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public courseId: number,
    private dialogRef: MatDialogRef<DeleteCourseDialogComponent>,
    private coursesService: CoursesService,
    private snackBar: MatSnackBar
  ) {}

  public async deleteCourse(): Promise<void> {
    var result = await this.coursesService.deleteCourse(this.courseId);

    if (result) {
      this.snackBar.open('Poprawnie usunięto kurs', 'Zamknij');

      this.dialogRef.close(true);
    } else {
      this.snackBar.open(
        'Usuwanie kursu się nie powiodło, wystąpił bład po stronie serwera',
        'Zamknij'
      );
    }
  }

  public closeDialog(): void {
    this.dialogRef.close();
  }
}
