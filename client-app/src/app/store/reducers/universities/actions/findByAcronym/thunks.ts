import { AsyncAction } from "../../../..";
import { default as api } from '../endpoints';
import { IUniversity } from "../../../../../models/universities/university";
import { LoadActions, LoadTypes } from "./types";
import { failedRequestingUniversity, requestingUniversity } from "../default/defaultActions";
import { AxiosError } from "axios";

const universityFoundSuccess = (universities: IUniversity[]): LoadActions => ({
    type: LoadTypes.GET_UNIVERSITY_BY_ACRONYM_SUCCESS,
    payload: universities
});

const findByAcronymAsync = (acronym: string): AsyncAction => async dispatch => {

    try {

        dispatch(requestingUniversity());

        const universities = await api.findByAcronym(acronym);

        dispatch(universityFoundSuccess(universities));

    }

    catch (ex) {
        
        const error = (ex as AxiosError).response!.data;

        dispatch(failedRequestingUniversity(error));
    
    }
}

export default findByAcronymAsync;