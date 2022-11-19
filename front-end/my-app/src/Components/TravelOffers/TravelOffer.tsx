import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Grid,
  Typography,
} from "@mui/material";
import GroupsIcon from "@mui/icons-material/Groups";
import "./_travelOffers.scss";

interface TravelOfferProps {
  title: string;
  date: string;
  description: string;
  image: string;
  imageLabel: string;
  price: number;
  peopleCount: number;
}

const TravelOffer: React.FC<TravelOfferProps> = ({
  title,
  date,
  description,
  image,
  imageLabel,
  price,
  peopleCount,
}) => {
  return (
    <Grid item xs={12} md={6}>
      <CardActionArea component="a" href="#">
        <Card sx={{ display: "flex" }}>
          <CardContent sx={{ flex: 1 }}>
            <Typography component="h2" variant="h5">
              {title}
            </Typography>
            <Typography variant="subtitle1" color="text.secondary">
              {date}
            </Typography>
            <Typography variant="subtitle1" paragraph>
              {description}
            </Typography>
            <div className="travel-offer-details">
              <span>{`${price}`}$</span>
              <span className="travel-offer-people-count">
                {peopleCount} <GroupsIcon />
              </span>
            </div>
            <Typography variant="subtitle1" color="primary">
              Daugiau
            </Typography>
          </CardContent>
          <CardMedia
            component="img"
            sx={{ width: 160, display: { xs: "none", sm: "block" } }}
            image={image}
            alt={imageLabel}
          />
        </Card>
      </CardActionArea>
    </Grid>
  );
};

export default TravelOffer;
