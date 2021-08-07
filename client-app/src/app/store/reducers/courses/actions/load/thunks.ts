import { AsyncAction } from "../../../..";
import { default as api } from '../endpoints';
import { ICourse } from "../../../../../models/courses/course";
import { LoadActions, LoadTypes } from "./types";
import { failedRequestingCourse, requestingCourse } from "../default/defaultActions";
import { AxiosError } from "axios";

const loadedCoursesSuccess = (courses: ICourse[]): LoadActions => ({
    type: LoadTypes.GET_COURSES_SUCCESS,
    payload: courses
});

const findCoursesAsync = (): AsyncAction => async dispatch => {

    try {

        dispatch(requestingCourse());

        const courses = await api.findAll();

        dispatch(loadedCoursesSuccess(courses));

    }

    catch (ex) {

    
        console.log(ex)
        const error = (ex as AxiosError).response!.data;

        dispatch(failedRequestingCourse(error));
    
    }
}

export default findCoursesAsync;