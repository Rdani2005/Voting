import axios from "axios";

export const GetAllVoters = () => {
    return axios
        .get<VotersModel[]>("http://localhost:5251/api/v1/votantes/")
        .then((res) => res.data)
        .catch((err) => err.message);
};

export const GetSingleVoter = (identification: String) => {
    console.log(
        `Consultando la URL http://localhost:5251/api/v1/votantes/id/${identification}`
    );
    return axios
        .get<VotersModel>(
            `http://localhost:5251/api/v1/votantes/id/${identification}`
        )
        .then((res) => res.data)
        .catch((err) => {
            alert("Votante No encontrado en BD. Contacte al administrador.");
            return err.message;
        });
};
