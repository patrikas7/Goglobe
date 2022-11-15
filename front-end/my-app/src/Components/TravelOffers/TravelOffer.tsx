import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Grid,
  Typography,
} from "@mui/material";

interface TravelOfferProps {
  title: string;
  date: string;
  description: string;
  image: string;
  imageLabel: string;
}

const TravelOffer: React.FC<TravelOfferProps> = ({
  title,
  date,
  description,
  image,
  imageLabel,
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
            <Typography variant="subtitle1" color="primary">
              Continue reading...
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
