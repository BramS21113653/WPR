import React from 'react';
import { Typography, Box, Container, Divider, useTheme, Paper } from '@mui/material';

const OverOns = () => {
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
    <Container maxWidth="md" sx={styles.container} >
      <Box component={Paper} elevation={4} sx={styles.mainContent}>
      <Typography variant="h3" component="h1" sx={styles.header}>
        Over ons
      </Typography>
      <Divider sx={styles.divider} />
      <Typography variant="body1" sx={styles.paragraph}>
        Stichting Accessibility zet zich in voor een digitaal, fysiek en sociaal toegankelijke samenleving.
        Een samenleving waarin iedereen zelfstandig kan meedoen en zich optimaal kan ontplooien, ook als je een 
        beperking hebt. Accessibility ondersteunt (maatschappelijke) organisaties bij het realiseren van 
        toegankelijkheid. Zo dragen wij bij aan een inclusieve samenleving met voorzieningen die toegankelijk en 
        bruikbaar zijn voor iedereen.
      </Typography>
      <Divider sx={styles.divider} />
      <Typography variant="h4" component="h2" sx={styles.subheader}>
        Onze missie
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Bij Accessibility werken we aan een inclusieve samenleving waarin iedereen kan meedoen en tot zijn recht komt.
        Steeds meer organisaties sluiten zich aan bij onze ambities. Al zoeken ze nog naar hoe ze dit voor elkaar kunnen 
        krijgen.
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Samen met onze klanten en partners bouwen we iedere dag aan een toegankelijker Nederland. We zetten onze kennis 
        en expertise in om fysieke, sociale én digitale omgevingen toegankelijk te maken; in het bijzonder voor mensen 
        met een (visuele) beperking.
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Onze experts denken graag met hen mee en bieden begeleiding op maat. Dit doen zij in nauwe samenwerking met ervaringsdeskundigen. Met onze trainingen, producten en diensten kan iedere organisatie morgen nog aan de slag met toegankelijkheid. Zo vertalen we onze kennis naar joúw praktijk.
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
      Jouw investering in toegankelijkheid is waardevol voor jouw bedrijf én voor de samenleving. Via Stichting Accessibility vloeit jouw investering terug naar projecten die bijdragen aan een toegankelijke en inclusieve samenleving. Sluit ook bij ons aan!
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Wij zijn Accessibility, expert in toegankelijkheid
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Samen met onze klanten en partners bouwen we iedere dag aan een toegankelijker Nederland. We zetten onze kennis 
        en expertise in om fysieke, sociale én digitale omgevingen toegankelijk te maken; in het bijzonder voor mensen 
        met een (visuele) beperking.
      </Typography>
      <Divider sx={styles.divider} />
      <Typography variant="h4" component="h2" sx={styles.subheader}>
        Achtergrond
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Begin deze eeuw digitaliseerde de samenleving in een rap tempo. Maar waren al die websites en digitale hulpmiddelen
        wel door iedereen te gebruiken? Toegankelijkheid stond nog in de kinderschoenen. Als eerste organisatie in 
        Nederland begon Stichting Accessibility in 2001 met het toegankelijk maken van ICT voor mensen met een visuele 
        beperking.
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Later verbreedden wij onze aandacht naar toegankelijkheid voor álle mensen met een (tijdelijke) beperking. Hierdoor zijn we sinds 2020 ook actief in de fysieke en sociale omgeving. Met onze experts werken we elke dag aan het verankeren van toegankelijkheid in organisaties in Nederland; van overheidsinstellingen tot bedrijven. Gelukkig kunnen we hierin met steeds meer partnerorganisaties optrekken. 
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Onze beweging blijft niet onopgemerkt. De regelgeving beweegt mee: mede dankzij onze inspanningen is de internationale richtlijn op het gebied van digitale websites en apps, de WCAG(externe link), gerealiseerd. Daarnaast denken we mee met diverse richtlijnen op inclusief design en fysieke toegankelijkheid.
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
      Stichting Accessibility heeft een ANBI-status en zit in de adviescommissie van het W3C.      
      </Typography>
      <Divider sx={styles.divider} />
      <Typography variant="h4" component="h2" sx={styles.subheader}>
        Nieuwsgierig naar onze vacatures?
      </Typography>
      <Typography variant="body1" sx={styles.paragraph}>
        Bekijk op deze pagina de vacatures die we momenteel open hebben staan. We bieden ook stageplekken!
      </Typography>
      </Box>
    </Container>
  );
};

export default OverOns;
