import { IOption } from "../../common/Select/Options";
import { IUniversity } from "../../models/universities/university";

export const mapUniversitiesToSelect = (universities: IUniversity[]) => {
    return universities?.map(university => ({
        label: `${university.acronym} - ${university.name}`,
        value: university.id
    } as IOption))
};