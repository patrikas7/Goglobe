import { Button } from "@mui/material";
import "./_offer.scss";

const Offer: React.FC = () => {
  return (
    <div className="travel-offer">
      <div className="travel-offer--left">
        <img src="https://media.cntraveler.com/photos/5a985924d41cc84048ce6db0/master/w_4348,h_3261,c_limit/Catedral-de-Barcelona-GettyImages-511874340.jpg" />
      </div>
      <div className="travel-offer--right">
        <h1>Barselona, Ispanija</h1>
        <span className="price">900$</span>
        <p className="description">
          Lorem Ipsum is simply dummy text of the printing and typesetting
          industry. Lorem Ipsum has been the industry's standard dummy text ever
          since the 1500s, when an unknown printer took a galley of type and
          scrambled it to make a type specimen book. It has survived not only
          five centuries, but also the leap into electronic typesetting,
          remaining essentially unchanged. It was popularised in the 1960s with
          the release of Letraset sheets containing Lorem Ipsum passages, and
          more recently with desktop publishing software like Aldus PageMaker
          including versions of Lorem Ipsum.
        </p>

        <div className="departure-dates">
          <p>Isvykimas 2022-12-07</p>
          <p>Atvykimas 2022-12-21</p>
        </div>

        <p className="hotel">Viesbutis: grand spa</p>

        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Uzsisakyti
        </Button>
      </div>
    </div>
  );
};

export default Offer;
