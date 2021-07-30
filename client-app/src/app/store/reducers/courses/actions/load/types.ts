import { ICourse } from "../../../../../models/courses/course";

/**
 * Action Types
 */
export enum LoadTypes {
    GET_COURSES_SUCCESS = "@course/GET_COURSES_SUCCESS"
};

/**
 * Action formats
 */
export interface LoadedCourses {
    type: typeof LoadTypes.GET_COURSES_SUCCESS;
    payload: ICourse[]
};


export type LoadActions = LoadedCourses;