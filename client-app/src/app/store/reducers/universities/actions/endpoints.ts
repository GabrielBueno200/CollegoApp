import { default as api } from '../../../../api';
import { IUniversity } from '../../../../models/universities/university';

export enum Endpoints {
    findByAcronym = "University/findByAcronym",
}

interface IUniversityRequester {
    findByAcronym: (acronym: string) => Promise<IUniversity[]>;
};

const ApiRequest : IUniversityRequester = {
    findByAcronym: (acronym: string) => api.get<IUniversity[]>(`${Endpoints.findByAcronym}/${acronym}`)
};

export default ApiRequest;
