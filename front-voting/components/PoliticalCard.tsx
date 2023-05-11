import React, { FunctionComponent } from "react";

const PoliticalCard: FunctionComponent<PoliticalPartyModel> = (party) => {
    return (
        <div className="border border-gray-500 w-[80%] mx-auto rounded-md">
            <img src={party.imgUrl + ""} alt="" className="w-full" />
            <div className="px-5">
                <h1 className="text-black text-center font-semibold text-lg">
                    {party.name}
                </h1>
                <button className="w-full h-14 rounded-xl text-white my-5 bg-green-500 hover:bg-green-600 transition-all">
                    Votar
                </button>
            </div>
        </div>
    );
};

export default PoliticalCard;
