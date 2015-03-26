#DataMaker Change log

### 1.0.1
**New**  
- New actions _XmlProxyGetXmlAsString_ and _XmlProxyRefreshStringContent_ to better handle saving xml content as string  
- new _XmlNodeRemoveAll_ action
- new demo showing how to load and save xml in playerprefs

**Fix**  
- Fixed _XmlGetNextnodeListProperties_ cache  
- Create StoreInMemory string property for _DataMakerXmlProxyEditor_  


**Improvement**  
- Added Reset option for _XmlGetNextnodeListProperties_  

### 1.0.0
**New**  
- MIT License Addition  
- Support for Ecosystem changeLog and versioning   
- Added Refresh and Save In Project for _DataMakerXmlProxyEditor_ pointing to TextAssets  

**Fix**
- Fixed contentPreview missing skin on some Unity  versions, now using Label explicitly.  
- Fixed caching of xml string content in _DataMakerXmlProxyEditor_ to reduce scene size with uncessary editor only data  
- Adds ArrayMaker to the packages ( it has xml addons custom actions)


**Improvement**   
- Undo support when adding xml proxy composent to GameObject  
- Moved to [public Github Repository](https://github.com/jeanfabre/PlayMaker--DataMaker) for visibility and better code management safety.  
- Menus now under PlayMaker/Addons for better/compliant organisation  


###0.9.0
**Note**   
- Initial release
