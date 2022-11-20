import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";

interface AgencyProps {
  name: string;
  address: string;
}

const Agency: React.FC<AgencyProps> = ({ name, address }) => {
  return (
    <Card sx={{ maxWidth: 345 }}>
      <CardActionArea>
        <CardMedia
          component="img"
          height="140"
          image="https://s1.15min.lt/images/photos/2019/08/02/original/novaturas-5d444c07bac76.jpg"
          alt="Agentura"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div" align="center">
            {name}
          </Typography>
          <Typography variant="body2" color="text.secondary" align="center">
            {address}
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
};

export default Agency;
