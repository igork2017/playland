using System;

public class CompareVersions{
    public void Run(){
        var version1="1.0";
        var version2="1.0.0";
        Console.WriteLine(CompareVersion(version1, version2));
    }
    public int CompareVersion(string version1, string version2) {
        var result=0;
        var arrayVersion1 = version1.Split('.');
        var arrayVersion2 = version2.Split('.');
        var minLength=Math.Min(arrayVersion1.Length, arrayVersion2.Length);
        for(int i=0; i<minLength; i++){
            int v1=0;
            int v2=0;
            Int32.TryParse(arrayVersion1[i], out v1);
            Int32.TryParse(arrayVersion2[i], out v2);
            if(v1>v2) return 1;
            if(v1<v2) return -1;
        }
        var sumOfRest=0;
        if(arrayVersion1.Length>arrayVersion2.Length){
            
            for(int j=minLength;j<arrayVersion1.Length;j++){
                int v1=0;
                Int32.TryParse(arrayVersion1[j], out v1);
                sumOfRest+=v1;
                if(sumOfRest>0) return 1;
            }
        }
        if(arrayVersion2.Length>arrayVersion1.Length){
             for(int j=minLength;j<arrayVersion2.Length;j++){
                int v2=0;
                Int32.TryParse(arrayVersion2[j], out v2);
                sumOfRest+=v2;                
            }
            if(sumOfRest>0) return -1;
        }
        return result;     
    }
}