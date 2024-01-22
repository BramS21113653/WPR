import React from 'react';
import { Typography, Box, Container, Divider, useTheme, Paper } from '@mui/material';

const Contact = () => {
  const theme = useTheme();

  const styles = {
    container: {
      marginTop: theme.spacing(8),
      marginBottom: theme.spacing(8),
    },
    mainContent: {
      padding: theme.spacing(3),
      margin: theme.spacing(2),
      [theme.breakpoints.up('md')]: {
        padding: theme.spacing(6),
      },
    },
    header: {
      color: theme.palette.primary.main,
      textAlign: 'center',
      margin: theme.spacing(0, 0),
    },
    subheader: {
      color: theme.palette.secondary.main,
      textAlign: 'center',
      margin: theme.spacing(3, 0),
    },
    divider: {
      margin: theme.spacing(3, 0),
    },
    paragraph: {
      textAlign: 'center',
      marginBottom: theme.spacing(2),
    },
  };

  return (
    <Container maxWidth="md" sx={styles.container}>
      <Box component={Paper} elevation={4} sx={styles.mainContent}>
        <Typography variant="h3" component="h1" sx={styles.header}>
          Contactgegevens
        </Typography>
        <Divider sx={styles.divider} />
        <Typography variant="body1" sx={styles.paragraph}>
          Stichting Accessibility is gevestigd in het bedrijfsverzamelgebouw de Krammstate op een paar minuten lopen van Station Utrecht Overvecht.
        </Typography>
        <Typography variant="h4" component="h2" sx={styles.subheader}>
          Bezoek- en postadres:
        </Typography>
        <Typography variant="body1" sx={styles.paragraph}>
          Christiaan Krammlaan 2<br />
          3571 AX Utrecht
        </Typography>
        <Typography variant="body1" sx={styles.paragraph}>
          Mocht je met de trein en bus komen dan kun je <a href="route-link">hier</a> de uitgebreide routebeschrijving raadplegen.
        </Typography>
        <Typography variant="body1" sx={styles.paragraph}>
          Algemene informatie over de toegankelijkheid, rolstoelvriendelijkheid en het meebrengen van geleidehonden staat op onze <a href="accessibility-info-link">pagina over de toegankelijkheid van ons kantoor</a>.
        </Typography>
        <Typography variant="h4" component="h2" sx={styles.subheader}>
          Contactgegevens:
        </Typography>
        <Typography variant="body1" sx={styles.paragraph}>
          Tel. <a href="tel:+31302398270">+31 30 239 82 70</a><br />
          E-mail: <a href="mailto:info@accessibility.nl">info@accessibility.nl</a>
        </Typography>
      </Box>
    </Container>
  );
};

export default Contact;
