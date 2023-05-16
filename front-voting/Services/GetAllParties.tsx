import axios from "axios";

const GetAllParties = () => {
    return axios
        .get<PoliticalPartyModel[]>("http://localhost:5251/api/v1/partidos/")
        .then((res) => res.data)
        .catch((err) => err.message);
};

export default GetAllParties;
