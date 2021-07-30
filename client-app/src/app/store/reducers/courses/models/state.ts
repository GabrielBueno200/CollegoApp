import { ICourse } from "../../../../models/courses/course";

export default interface ICourseState {
    readonly data: ICourse[] | [],
    readonly pending: boolean,
    readonly error?: any
};