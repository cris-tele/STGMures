# STGMures Statistical project

This is a pro bono project!

The beneficiary is the Tg Mures hospital, Romania,https://ibcvt.ro/.
Hospital's moto is a very simple one: "WE CARE ABOUT YOUR HEART!".
Yes, this is one of the few Romanian hospitals where newborns can be treated for heart diseases. 

So, if you want to contribute to this pro-bono project, well, I am asking for help in finalizing this endeavor. Just work & ideas.
I am not a versed C# developer, nor a very good designer... but those are not reason to stop working. After all, I will learn a lot of stuff.
Any peace of code, advice, design tips of the pages, or even simply general advices will be highly appreciated.
I am a mechanical engineer so... those medical terms are very confusing to me :), any help to understand how the real things work will be apreciated.

Now, about the project, I've choose .NET7, blazor webassembly:

  the project must be web based: one requirement it has to be accessible from work or from home (a surgery usually takes more than 8 hours, so maybe someone want to check the results remote, no?)...) ;
  
  it has to be fast (because it is destinated to the anesthesia and intensive care department from this hospital);
  
  it has to use Microsoft core libraries (I don't believe somebody will pay for custom controls, it's a public institute that means they have to initiate a public acquisition procedure… a nightmare);
  
  web assemblies because some API' will be used by other apps or even devices? (Blood pressure, cardiac rhythm, automatic dosage of substances… probably could be received and not entered manually; for now, it’s manually 😊);
  
I've chosen MS SQL Express server (it is free an easier for the development phase – Integrated in Visual Studio Community Edition; for production… will see).

The model and some code are from Patrick God's tutorials 😊. I recomd those.

The 'requirements', well, It's an excel file, feel free to analyze it (see the dummy folder) 

The final scope: to create a good statistical tool for the medical staff! That means graphics, pivot tables (excel?), reports... don't knw more yet.
For now, the project's goal is to collect all the data 😊.

Thx,
Cristian.



