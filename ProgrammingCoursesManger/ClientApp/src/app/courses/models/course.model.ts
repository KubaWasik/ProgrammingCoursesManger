import { TopicModel } from "./topic.model";

export class CourseModel {
  id!: number;
  name!: string;
  description!: string;

  topics: TopicModel[] = [];
}
