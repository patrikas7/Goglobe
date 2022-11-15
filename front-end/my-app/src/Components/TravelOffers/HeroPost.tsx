import { Box, Grid, Paper, Typography } from "@mui/material";

interface HeroPost {
  image: string;
  imageText: string;
  title: string;
}

const HeroPost: React.FC<HeroPost> = ({ image, imageText, title }) => {
  return (
    <Paper
      sx={{
        position: "relative",
        backgroundColor: "grey.800",
        color: "#fff",
        mb: 4,
        backgroundSize: "cover",
        backgroundRepeat: "no-repeat",
        backgroundPosition: "center",
        backgroundImage: `url(${image})`,
        height: "250px",
      }}
    >
      {<img style={{ display: "none" }} src={image} alt={imageText} />}
      <Box
        sx={{
          position: "absolute",
          top: 0,
          bottom: 0,
          right: 0,
          left: 0,
          backgroundColor: "rgba(0,0,0,.3)",
        }}
      />
      <Grid container>
        <Grid item md={6}>
          <Box
            sx={{
              position: "relative",
              p: { xs: 3, md: 6 },
              pr: { md: 0 },
            }}
          >
            <Typography component="h3" variant="h2">
              {title}
            </Typography>
          </Box>
        </Grid>
      </Grid>
    </Paper>
  );
};

export default HeroPost;
