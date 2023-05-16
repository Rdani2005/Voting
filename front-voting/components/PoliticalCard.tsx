import { useVoterContext } from "@/app/context/VoterStore";
import { data } from "autoprefixer";
import axios from "axios";
import React, { FunctionComponent } from "react";

const PoliticalCard: FunctionComponent<PoliticalPartyModel> = (party) => {
    const { actualVoter, setActualVoter } = useVoterContext();

    const Vote = () => {
        const config = {
            headers: { "Content-Type": "application/json" },
        };

        try {
            const response = axios.post(
                `http://localhost:5251/api/v1/voter/${
                    actualVoter!.id
                }/vote/confirm`,
                { PartyId: party.id },
                config
            );
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="border border-gray-500 w-[80%] mx-auto rounded-md">
            <img src={party.imageUrl + ""} alt="" className="w-full" />
            <div className="px-5">
                <h1 className="text-black text-center font-semibold text-lg">
                    {party.name}
                </h1>
                <button
                    className="w-full h-14 rounded-xl text-white my-5 bg-green-500 hover:bg-green-600 transition-all"
                    onClick={() => Vote()}
                >
                    Votar
                </button>
            </div>
        </div>
    );
};

export default PoliticalCard;
