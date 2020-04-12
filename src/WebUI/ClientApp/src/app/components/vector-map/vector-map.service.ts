import { Injectable } from "@angular/core";
import { scaleLinear } from "d3-scale";

const popScale = scaleLinear()
  .domain([0, 100])
  .range(["red", "black"]);

export class Country {
  color: string;
}

export class Countries {
  Russia: Country;
  Canada: Country;
  China: Country;
  "United States": Country;
  Brazil: Country;
  Australia: Country;
  India: Country;
  Argentina: Country;
  Romania: Country;
  Algeria: Country;
  France: Country;
  Belgium: Country;
  Luxembourg: Country;
  Italy: Country;
  Spain: Country;
  Morocco: Country;
  Portugal: Country;
}

let countries: Countries = {
  Russia: { color: popScale(10) },
  Canada: { color: popScale(10) },
  China: { color: popScale(20) },
  "United States": { color: popScale(50) },
  Brazil: { color: popScale(10) },
  Australia: { color: popScale(10) },
  India: { color: popScale(10) },
  Argentina: { color: popScale(10) },
  Romania: { color: popScale(10) },
  Algeria: { color: popScale(10) },
  France: { color: popScale(60)},
  Belgium: { color: popScale(75)},
  Luxembourg: { color: popScale(30)},
  Italy: { color: popScale(100)},
  Spain: { color: popScale(70)},
  Morocco: { color: popScale(50)},
  Portugal: { color: popScale(40)}

};

@Injectable({
  providedIn: 'root',
})
export class Service {
  getCountries(): Countries {
    return countries;
  }
}
