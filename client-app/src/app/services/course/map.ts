import { IOption } from "../../common/Select/Options";
import { ICourse } from "../../models/courses/course";

export const mapCoursesToSelect = (courses: ICourse[]) => {
    return courses?.map(course => ({
        label: course.name.toUpperCase(),
        value: course.id
    } as IOption))
};