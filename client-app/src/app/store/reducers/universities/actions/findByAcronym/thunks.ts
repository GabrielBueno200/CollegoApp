import { AsyncAction } from "../../../..";
import { default as api } from '../endpoints';
import { IUniversity } from "../../../../../models/universities/university";
import { LoadActions, LoadTypes } from "./types";
import { failedRequestingUniversity, requestingUniversity } from "../default/defaultActions";
import { AxiosError } from "axios";

const universityFoundSuccess = (university: IUniversity): LoadActions => ({
    type: LoadTypes.GET_UNIVERSITY_BY_ACRONYM_SUCCESS,
    payload: university
});

const findByAcronymAsync = (acronym: string): AsyncAction => async dispatch => {

    try {

        dispatch(requestingUniversity());

        const university = await api.findByAcronym(acronym);

        dispatch(universityFoundSuccess(university));

    }

    catch (ex) {
        
        const error = (ex as AxiosError).response!.data;

        dispatch(failedRequestingUniversity(error));
    
    }
}

export default findByAcronymAsync;